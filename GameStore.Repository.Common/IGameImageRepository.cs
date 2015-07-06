using GameStore.Model.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Repository.Common
{
    public interface IGameImageRepository
    {
        Task<IGameImage> GetAsync(Guid id);
        Task<IEnumerable<IGameImage>> GetRangeAsync();
        Task<IEnumerable<IGameImage>> GetRangeAsync(Guid gameId);
        Task<int> AddAsync(IGameImage gameImate);
        Task<int> UpdateAsync(IGameImage gameImage);
        Task<int> DeleteAsync(IGameImage gameImage);
    }

}
