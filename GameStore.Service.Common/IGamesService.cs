﻿using GameStore.Common;
using GameStore.Model.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Common
{
    public interface IGamesService
    {
        Task<IGame> GetAsync(Guid id);
        Task<IEnumerable<IGame>> GetRangeAsync(string name);
        Task<IEnumerable<IGame>> GetRangeAsync(GameFilter filter = null);
        Task<IEnumerable<IGame>> GetRangeAsync(Guid publisherId);
    }
}
