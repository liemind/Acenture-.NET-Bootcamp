using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Salvo.Models;

namespace Salvo.Repositories
{
    public class GameRepository : RepositoryBase<Game>, IGameRepository
    {
        public GameRepository(SalvoContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
