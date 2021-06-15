using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Salvo.Models;
using Salvo.Models.DTO;
using Salvo.Repositories;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Salvo.Controllers
{
    [Route("api/players")]
    [ApiController]
    [Authorize]
    public class PlayersController : ControllerBase
    {
        private IPlayerRepository _repository;
        public PlayersController(IPlayerRepository repository)
        {
            _repository = repository;
        }

        // GET api/<PlayersController>/5
        [HttpGet("{id}", Name = "GetPlayer")]
        [AllowAnonymous]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PlayersController>
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Post([FromBody] PlayerDTO player)
        {
            try
            {
                //validte data
                if (String.IsNullOrEmpty(player.Email) || String.IsNullOrEmpty(player.Password))
                {
                    return StatusCode(403, "Error in data");
                }

                //find if data exist in bd
                var playerToFind = _repository.FindByEmail(player.Email);
                if (playerToFind != null)
                {
                    return StatusCode(403, "Email exist");
                }

                Player NewPlayer = new Player
                {
                    Email = player.Email,
                    Password = player.Password
                };
                _repository.Save(NewPlayer);

                return StatusCode(201, NewPlayer);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
