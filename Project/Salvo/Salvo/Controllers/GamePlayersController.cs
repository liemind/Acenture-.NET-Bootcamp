using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Salvo.Models.DTO;
using Salvo.Models;
using Salvo.Repositories;
using System;
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

        public GamePlayersController( IGamePlayerRepository repository)
        {
            _repository = repository;
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

        // POST api/<GamePlayersController>
        //[HttpPost]
        //public ActionResult Post()
        //{
        //    try
        //    {
        //        //about player
        //        var userEmail = GetSessionEmail();
        //        Player playerGame = _repositoryPlayer.FindByEmail(userEmail);

        //        //about Game
        //        //Game NewGame = NewGame()

        //        return StatusCode(201, "");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("{0} Exception caught.", ex);
        //        return StatusCode(500, "Internal server error");
        //    }
        //}

        //// PUT api/<GamePlayersController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<GamePlayersController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
