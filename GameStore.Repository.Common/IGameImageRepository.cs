using GameStore.Common;
using GameStore.Model.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Repository.Common
{
    /// <summary>
    /// Defines method signatures for game image repository
    /// </summary>
    public interface IGameImageRepository
    {
        Task<IGameImage> GetAsync(Guid id);
        Task<IEnumerable<IGameImage>> GetRangeAsync(GenericFilter filter);
        Task<IEnumerable<IGameImage>> GetRangeAsync(Guid gameId, GenericFilter filter);
        Task<int> AddAsync(IGameImage gameImate);
        Task<int> UpdateAsync(IGameImage gameImage);
        Task<int> DeleteAsync(IGameImage gameImage);
    }

}
