using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Salvo.Models.DTO;
using Salvo.Repositories;
using System;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Salvo.Controllers
{
    [Route("api/games")]
    [ApiController]
    [Authorize]
    public class GamesController : ControllerBase
    {
        private IGameRepository _repository;
        public GamesController(IGameRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get()
        {
            try
            {
                var user = User.Claims.FirstOrDefault()?.Value;
                var games = _repository.GetAllGamesWithPlayers()
                .Select(g => new GameDTO
                {
                    Id = g.Id,
                    CreationDate = g.CreationDate,
                    GamePlayers = g.GamePlayers.Select(
                        gp => new GamePlayerDTO
                        {
                            Id = gp.Id,
                            JoinDate = gp.JoinDate,
                            player = new PlayerDTO
                            {
                                Id = gp.Player.Id,
                                Email = gp.Player.Email
                            },
                            Point = gp.Player.GetScore(g) != null ? (double?)gp.Player.GetScore(g).Point : null
                        }).ToList()
                }).ToList();


                var gameAuth = new GameListDTO
                {
                    Email = user != null ? user : "Guest",
                    games = games
                };

                return Ok(gameAuth);
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);
                return StatusCode(500, "Internal server error");
            }
        }

        // GET: api/<GamesController>
        /*
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        **/

        //// GET api/<GamesController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<GamesController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<GamesController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<GamesController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
