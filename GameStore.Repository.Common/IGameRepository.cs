﻿using GameStore.Common;
using GameStore.Model.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Repository.Common
{
    public interface IGameRepository 
    {
        Task<IGame> GetAsync(Guid id);
        Task<IEnumerable<IGame>> GetRangeAsync(string name);
        Task<IEnumerable<IGame>> GetRangeAsync(GameFilter filter = null);
        Task<IEnumerable<IGame>> GetRangeAsync(Guid publisherId);

        Task<int> UpdateAsync(IGame game);
        Task<int> AddAsync(IGame game);
        Task<int> DeleteAsync(IGame game);
        Task<int> DeleteAsync(Guid id);

    }
}
