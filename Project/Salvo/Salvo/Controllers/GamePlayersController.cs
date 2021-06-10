using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Salvo.Models;
using Salvo.Models.DTO;
using Salvo.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Salvo.Controllers
{
    [Route("api/gamePlayers")]
    [ApiController]
    [Authorize("PlayerOnly")]
    public class GamePlayersController : ControllerBase
    {
        private IGamePlayerRepository _repository;
        private IPlayerRepository _repositoryPlayer;

        public GamePlayersController(IGamePlayerRepository repository, IPlayerRepository repositoryp)
        {
            _repository = repository;
            _repositoryPlayer = repositoryp;
        }

        public string GetSessionEmail()
        {
            return User.Claims.FirstOrDefault() != null ? User.Claims.FirstOrDefault().Value : "Guest";
        }

        // GET api/<GamePlayersController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                //get session email
                var user = GetSessionEmail();
                if (user != null)
                {
                    var gp = _repository.GetGamePlayerView(id);
                    if (gp.Player.Email != user)
                    {
                        return Forbid();
                    }
                    GameViewDTO gameView = new GameViewDTO
                    {
                        Id = gp.Id,
                        CreationDate = gp.JoinDate,
                        gamePlayers = gp.Game.GamePlayers.Select(
                            gpp => new GamePlayerDTO
                            {
                                Id = gpp.Id,
                                JoinDate = gpp.JoinDate,
                                player = new PlayerDTO
                                {
                                    Id = gpp.Player.Id,
                                    Email = gpp.Player.Email
                                }
                            }).ToList(),
                        ships = gp.Ships.Select(
                            ship => new ShipDTO
                            {
                                Id = ship.Id,
                                Type = ship.Type,
                                Locations = ship.Locations.Select(
                                    shlocation => new ShipLocationDTO
                                    {
                                        Id = shlocation.Id,
                                        Location = shlocation.Location
                                    }).ToList()
                            }).ToList(),
                        salvos = gp.Salvos.Select(
                            salvo => new SalvoDTO
                            {
                                Id = salvo.Id,
                                Turn = salvo.Turn,
                                player = new PlayerDTO
                                {
                                    Id = salvo.GamePlayer.Player.Id,
                                    Email = salvo.GamePlayer.Player.Email
                                },
                                locations = salvo.Locations.Select(
                                        salvol => new SalvoLocationDTO
                                        {
                                            Id = salvol.Id,
                                            Location = salvol.Cell
                                        }).ToList()
                            }).ToList()
                    };
                    return Ok(gameView);
                }
                return Unauthorized();
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("{id}/ships")]
        public IActionResult Post(int id, [FromBody] ShipDTO[] ships)
        {
            try
            {
                //ships
                if (ships == null)
                {
                    return StatusCode(403, "No hay barcos");
                }

                //get player.
                var user = GetSessionEmail();
                Player player = _repositoryPlayer.FindByEmail(user);
                //get gp
                GamePlayer gamePlayer = _repository.FindById(id);
                if (gamePlayer == null)
                {
                    return StatusCode(403, "No existe el juego");
                }
                if (gamePlayer.Player.Id != player.Id)
                {
                    return StatusCode(403, "El usuario no se encuentra en el juego");
                }
                if (gamePlayer.Ships.Count == 5)
                {
                    return StatusCode(403, "Ya se han posicionado los barcos");
                }

                //saved
                gamePlayer.Ships = ships.Select(
                    ship => new Ship
                    {
                        GamePlayerId = gamePlayer.Id,
                        Type = ship.Type,
                        Locations = ship.Locations.Select(
                            shiplocations => new ShipLocation
                            {
                                Location = shiplocations.Location
                            }).ToList()
                    }).ToList();


                _repository.Save(gamePlayer);
                return StatusCode(201, "Barcos posicionados!!");

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("{id}/salvos")]
        public IActionResult Post(int id, [FromBody] SalvoDTO salvos)
        {
            try
            {
                //salvos
                if (salvos == null)
                {
                    return StatusCode(403, "No hay salvos");
                }

                //get player.
                var user = GetSessionEmail();
                Player player = _repositoryPlayer.FindByEmail(user);
                //get gp
                GamePlayer gamePlayer = _repository.FindById(id);
                if (gamePlayer == null)
                {
                    return StatusCode(403, "No existe el juego");
                }
                if (gamePlayer.Player.Id != player.Id)
                {
                    return StatusCode(403, "El usuario no se encuentra en el juego");
                }
                //oponent
                GamePlayer opponent = gamePlayer.GetOpponent();

                //turns
                int userTurn = 0;
                int opponentTurn = 0;

                userTurn = gamePlayer.Salvos != null ? gamePlayer.Salvos.Count() + 1 : 1;
                if(opponent != null)
                {
                    opponentTurn = opponent.Salvos != null ? opponent.Salvos.Count() : 0;
                }
                //verify if turn is ok
                if ((userTurn - opponentTurn) < -1 || (userTurn - opponentTurn) > 1)
                {
                    return StatusCode(403, "No se puede adelantar el turno");
                }

                //saved
                gamePlayer.Salvos.Add(new Models.Salvo
                {
                    GamePlayerId = gamePlayer.Id,
                    Turn = userTurn,
                    Locations = salvos.locations.Select(
                            salvoLocations => new SalvoLocation
                            {
                                Cell = salvoLocations.Location
                            }).ToList()
                });
                _repository.Save(gamePlayer);

                return StatusCode(201, "Salvos disparados!!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
