using Microsoft.AspNetCore.Mvc;
using Salvo.Repositories;
using System;
using System.Linq;
using Salvo.Models.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Salvo.Controllers
{
    [Route("api/games")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private IGameRepository _repository;

        public GamesController(IGameRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var gamer = _repository.GetAllGamesWithPlayers()
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
                            }
                        }).ToList()
                });
                return Ok(gamer);
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
