using GameStore.Common;
using GameStore.Model.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Service.Common
{
    /// <summary>
    /// Defines method signatures for game image service
    /// </summary>
    public interface IGameImageService
    {
        Task<IEnumerable<IGameImage>> GetRangeAsync(Guid GameId, GenericFilter filter);
    }
}
