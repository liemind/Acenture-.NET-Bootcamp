using Microsoft.EntityFrameworkCore;
using Salvo.Models;
using System.Collections.Generic;
using System.Linq;

namespace Salvo.Repositories
{
    public class GameRepository : RepositoryBase<Game>, IGameRepository
    {
        public GameRepository(SalvoContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<Game> GetAllGames()
        {
            return FindAll()
                .OrderBy(ow => ow.CreationDate)
                .ToList();
        }

        public IEnumerable<Game> GetAllGamesWithPlayers()
        {
            return FindAll(source => source.Include(game => game.GamePlayers)
                    .ThenInclude(gameplayer => gameplayer.Player))
                .OrderBy(game => game.CreationDate)
                .ToList();
        }
    }
}
