using GameStore.Model.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Service.Common
{
    public interface IGameImageService
    {
        Task<IEnumerable<IGameImage>> GetRangeAsync(Guid GameId);
    }
}
