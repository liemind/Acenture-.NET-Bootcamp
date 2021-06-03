using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Salvo.Models;

namespace Salvo.Repositories
{
    public class PlayerRepository : RepositoryBase<Player>, IPlayerRepository
    {
        public PlayerRepository(SalvoContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public Player findByEmail(string email)
        {
            return FindAll()
                .Where(player => player.Email == email)
                .FirstOrDefault();
        }
    }
}
