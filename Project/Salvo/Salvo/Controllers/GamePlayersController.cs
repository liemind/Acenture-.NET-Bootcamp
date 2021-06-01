﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Salvo.Models.DTO;
using Salvo.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Salvo.Controllers
{
    [Route("api/gamePlayers")]
    [ApiController]
    public class GamePlayersController : ControllerBase
    {
        private IGamePlayerRepository _repository;

        public GamePlayersController(IGamePlayerRepository repository)
        {
            _repository = repository;
        }

        //// GET: api/<GamePlayersController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<GamePlayersController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var gp = _repository.GetGamePlayerView(id);
                GameViewDTO gameView = new GameViewDTO
                {
                    Id=gp.Id,
                    CreationDate=gp.JoinDate,
                    gamePlayers= gp.Game.GamePlayers.Select(
                        gpp => new GamePlayerDTO
                        {
                            Id=gpp.Id,
                            JoinDate=gpp.JoinDate,
                            player = new PlayerDTO
                            {
                                Id = gp.Player.Id,
                                Email = gp.Player.Email
                            }
                        }).ToList(),
                    ships=gp.Ships.Select(
                        ship => new ShipDTO
                        {
                            Id = ship.Id,
                            Type = ship.Type,
                            Locations = ship.Locations.Select( 
                                shlocation => new ShipLocationDTO {
                                    Id = shlocation.Id,
                                    Location = shlocation.Location
                                }).ToList()
                        }).ToList()
                };

                return Ok(gameView);
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);
                return StatusCode(500, "Internal server error");
            }
        }

        //// POST api/<GamePlayersController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
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