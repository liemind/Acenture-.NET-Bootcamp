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
    [Route("api/games")]
    [ApiController]
    [Authorize]
    public class GamesController : ControllerBase
    {
        private IGameRepository _repository;
        private IPlayerRepository _repositoryPlayer;
        private IGamePlayerRepository _repositoryGP;
        public GamesController(IGameRepository repository, IPlayerRepository repositoryp, IGamePlayerRepository repositorygp)
        {
            _repository = repository;
            _repositoryPlayer = repositoryp;
            _repositoryGP = repositorygp;
        }

        public string GetSessionEmail()
        {
            return User.Claims.FirstOrDefault() != null ? User.Claims.FirstOrDefault().Value : "Guest";
        }

        public GamePlayer FindPlayerInGamePlayers(ICollection<GamePlayer> gamePlayer, long Id)
        {
            return gamePlayer.Where(gp => gp.Player.Id == Id).FirstOrDefault();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get()
        {
            try
            {
                var user = GetSessionEmail();
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
                    Email = user,
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

        [HttpPost]
        public IActionResult Post()
        {
            try
            {
                //about player
                var userEmail = GetSessionEmail();
                Player playerGame = _repositoryPlayer.FindByEmail(userEmail);

                //about GamePlayer
                GamePlayer newGamePlayer = new GamePlayer
                {
                    JoinDate = System.DateTime.Now,
                    PlayerId = playerGame.Id,
                    Game = new Game
                    {
                        CreationDate = System.DateTime.Now
                    }
                };
                //save all
                _repositoryGP.Save(newGamePlayer);
                return StatusCode(201, newGamePlayer.Id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("{id}/players")]
        public IActionResult Join(int id)
        {
            try
            {
                //get player
                String user = GetSessionEmail();
                Player player = _repositoryPlayer.FindByEmail(user);

                //get game with id
                Game game = _repository.FindById(id);
                if (game == null)
                {
                    return StatusCode(403, "No existe el juego");
                }

                //if player exist in game
                if (FindPlayerInGamePlayers(game.GamePlayers, player.Id) != null)
                {
                    return StatusCode(403, "Ya se encuentra el jugador en el juego");
                }

                //if player get only one player
                if (game.GamePlayers.Count > 1)
                {
                    return StatusCode(403, "Juego lleno");
                }

                //Create a new Gameplayer with PlayerId and GameId;
                GamePlayer newGamePlayer = new GamePlayer
                {
                    JoinDate = System.DateTime.Now,
                    PlayerId = player.Id,
                    GameId = game.Id
                };

                //save all
                _repositoryGP.Save(newGamePlayer);
                return StatusCode(201, newGamePlayer.Id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


    }
}
