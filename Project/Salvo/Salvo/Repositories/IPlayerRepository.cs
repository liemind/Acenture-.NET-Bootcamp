using Salvo.Models;

namespace Salvo.Repositories
{
    public interface IPlayerRepository : IRepositoryBase<Player>
    {
        void Save(Player player);
        Player FindByEmail(string email);
    }
}
