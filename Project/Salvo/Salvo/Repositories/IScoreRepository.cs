using Salvo.Models;

namespace Salvo.Repositories
{
    public interface IScoreRepository : IRepositoryBase<Score>
    {
        void Save(Score score);
    }
}
