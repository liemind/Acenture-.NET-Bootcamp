using Salvo.Models;

namespace Salvo.Repositories
{
    public interface IGamePlayerRepository : IRepositoryBase<GamePlayer>
    {
        GamePlayer GetGamePlayerView(int idGamePlayer);
    }
}
