using Microsoft.EntityFrameworkCore;
using Salvo.Models;
using System.Linq;

namespace Salvo.Repositories
{
    public class GamePlayerRepository : RepositoryBase<GamePlayer>, IGamePlayerRepository
    {

        public GamePlayerRepository(SalvoContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public GamePlayer GetGamePlayerView(int idGamePlayer)
        {
            return FindAll(source => source.Include(gamePlayer => gamePlayer.Ships)
                                                .ThenInclude(ship => ship.Locations)
                                            .Include(gamePlayer => gamePlayer.Salvos)
                                                .ThenInclude(salvo => salvo.Locations)
                                            .Include(gamePlayer => gamePlayer.Game)
                                                .ThenInclude(game => game.GamePlayers)
                                                    .ThenInclude(gp => gp.Player)
                                            .Include(gamePlayer => gamePlayer.Game)
                                                .ThenInclude(game => game.GamePlayers)
                                                    .ThenInclude(gp => gp.Salvos)
                                                    .ThenInclude(salvo => salvo.Locations)
                                            .Include(gamePlayer => gamePlayer.Game)
                                                .ThenInclude(game => game.GamePlayers)
                                                    .ThenInclude(gp => gp.Ships)
                                                    .ThenInclude(ship => ship.Locations)
                                            )
                .Where(gamePlayer => gamePlayer.Id == idGamePlayer)
                .OrderBy(game => game.JoinDate)
                .FirstOrDefault();
        }

        public GamePlayer FindById(int id)
        {
            return FindByCondition(gp => gp.Id == id)
                .Include(gp => gp.Ships)
                    .ThenInclude(ship => ship.Locations)
                .Include(gp => gp.Player)
                .FirstOrDefault();
        }

        public void Save(GamePlayer gamePlayer)
        {
            if (gamePlayer.Id == 0)
            {
                Create(gamePlayer);
            }
            else
            {
                Update(gamePlayer);
            }
            SaveChanges();
        }
    }
}
