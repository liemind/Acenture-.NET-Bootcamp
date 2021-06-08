using Salvo.Models;
using System.Collections.Generic;

namespace Salvo.Repositories
{
    public interface IGameRepository : IRepositoryBase<Game>
    {
        IEnumerable<Game> GetAllGames();
        IEnumerable<Game> GetAllGamesWithPlayers();
        void Save(Game game);
        Game FindById(int Id);
    }
}
