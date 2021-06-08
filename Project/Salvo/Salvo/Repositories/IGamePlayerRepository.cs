using Salvo.Models;

namespace Salvo.Repositories
{
    public interface IGamePlayerRepository : IRepositoryBase<GamePlayer>
    {
        GamePlayer GetGamePlayerView(int idGamePlayer);
        void Save(GamePlayer gamePlayer);
        GamePlayer FindById(int id);
    }
}
