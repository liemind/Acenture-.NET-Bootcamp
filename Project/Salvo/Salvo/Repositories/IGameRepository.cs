﻿using Salvo.Models;
using System.Collections.Generic;

namespace Salvo.Repositories
{
    public interface IGameRepository : IRepositoryBase<Game>
    {
        IEnumerable<Game> GetAllGames();
    }
}