using Salvo.Models;
using System.Linq;

namespace Salvo.Repositories
{
    public class PlayerRepository : RepositoryBase<Player>, IPlayerRepository
    {
        public PlayerRepository(SalvoContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public Player FindByEmail(string email)
        {
            return FindAll()
                .Where(player => player.Email == email)
                .FirstOrDefault();
        }
    }
}
