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
            int lastTurn = Salvos.Count;
            //get the opponent locations
            List<string> salvoLocations = this.GetOpponent()?.Salvos
                .Where(salvo => salvo.Turn <= lastTurn)
                .SelectMany(salvo => salvo.Locations.Select(location => location.Cell)).ToList();
            //return opponent ship type
            return Ships?.Where(ship => ship.Locations.Select(shipLocation => shipLocation.Location)
                        .All(salvoLocation => salvoLocations != null ? salvoLocations.Any(shipLocation => shipLocation == salvoLocation) : false))
                        .Select(ship => ship.Type).ToList();
        }


    }
}
