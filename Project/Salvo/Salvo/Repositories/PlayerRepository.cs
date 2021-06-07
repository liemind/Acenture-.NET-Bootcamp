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
        public void Save(Player player)
        {
            Create(player);
            SaveChanges();
        }

        public Player FindByEmail(string email)
        {
            return FindByCondition(player => player.Email == email)
                .OrderBy(player => player.Email)
                .FirstOrDefault();
        }

    }
}
