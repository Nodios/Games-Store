using GameStore.Common;
using GameStore.Model.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Repository.Common
{
    public interface IPostRepository
    {
        Task<IPost> GetAsync(Guid id);
        Task<IEnumerable<IPost>> GetRangeAsync(Guid gameId,GenericFilter GenericFilter);
        Task<int> UpdateAsync(IPost post);
        Task<int> AddAsync(IPost post);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(IPost post);
    }
}
