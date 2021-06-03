using Salvo.Models;

namespace Salvo.Repositories
{
    public interface IPlayerRepository : IRepositoryBase<Player>
    {
        Player FindByEmail(string email);
    }
}
