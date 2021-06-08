using Salvo.Models;
using System;

namespace Salvo.Repositories
{
    public interface IGamePlayerRepository : IRepositoryBase<GamePlayer>
    {
        GamePlayer GetGamePlayerView(int idGamePlayer);
        void Save(GamePlayer gamePlayer);
    }
}
