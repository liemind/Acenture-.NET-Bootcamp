using Salvo.Models.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Salvo.Models
{
    public class GamePlayer
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public DateTime? JoinDate { get; set; }
        public long GameId { get; set; }
        [ForeignKey("GameId")]
        public Game Game { get; set; }
        public long PlayerId { get; set; }
        [ForeignKey("PlayerId")]
        public Player Player { get; set; }

        public ICollection<Ship> Ships { get; set; }
        public ICollection<Salvo> Salvos { get; set; }


        public Score GetScore()
        {
            return Player.GetScore(Game);
        }

        public GamePlayer GetOpponent()
        {
            return this.Game.GamePlayers.FirstOrDefault(gp => gp.Id != Id);
        }

        public ICollection<SalvoHitDTO> GetHits()
        {
            //for all the salvos, return the intersection between user salvos and opponen ships
            return Salvos?.Select(salvo => new SalvoHitDTO
            {
                turn = salvo.Turn,
                hits = GetOpponent()?.Ships.Select(ship => new HitDTO
                {
                    type = ship.Type,
                    hits = salvo.Locations
                            .Where(salvoLocation => ship.Locations.Any(shipLocation => shipLocation.Location == salvoLocation.Cell))
                            .Select(salvoLocation => salvoLocation.Cell).ToList()
                }).ToList()
            }).ToList();

        }

        public List<string> GetStunks()
        {
            //identify last turn
            int lastTurn = Salvos.Count + 1;
            //get the opponent locations
            List<string> salvoLocations = this.GetOpponent()?.Salvos
                .Where(salvo => salvo.Turn <= lastTurn)
                .SelectMany(salvo => salvo.Locations.Select(location => location.Cell)).ToList();
            //return opponent ship type
            return Ships?.Where(ship => ship.Locations.Select(shipLocation => shipLocation.Location)
                        .All(salvoLocation => salvoLocations != null ? salvoLocations.Any(shipLocation => shipLocation == salvoLocation) : false))
                        .Select(ship => ship.Type).ToList();
        }

        public GameState GetGameState()
        {
            GameState gameState = GameState.ENTER_SALVO;

            if (Ships == null || Ships?.Count() == 0)
            {
                gameState = GameState.PLACE_SHIPS;
            }
            //Player places ships: wait
            else if (GetOpponent() == null)
            {
                //salvos count
                if (Salvos != null && Salvos?.Count() > 0)
                {
                    if (Salvos?.Count > 0 && Salvos != null)
                    {
                        gameState = GameState.WAIT;
                    }
                }
            }
            //All ships placed: Enter salvo
            else
            {
                //opponent
                GamePlayer opponent = GetOpponent();
                int opponentTurn = opponent.Salvos != null ? opponent.Salvos.Count() : 0;

                //user
                int userTurn = Salvos != null ? Salvos.Count() : 0;

                if (userTurn > opponentTurn)
                {
                    gameState = GameState.WAIT;
                }
                else if (userTurn == opponentTurn && userTurn != 0)
                {
                    List<string> strunksUser = this.GetStunks();
                    List<string> strunksOpponent = opponent.GetStunks();

                    if (strunksUser.Count == Ships.Count() &&
                        strunksOpponent.Count == opponent.Ships.Count())
                    {
                        gameState = GameState.TIE;
                    }

                    else if (strunksUser.Count() == Ships.Count())
                    {
                        gameState = GameState.LOSS;
                    }
                    else if (strunksOpponent.Count() == opponent.Ships.Count())
                    {
                        gameState = GameState.WIN;
                    }
                }
            }

            // Player creates / joins game: Place ships
            return gameState;
        }
    }
}
