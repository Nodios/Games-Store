using GameStore.Common;
using GameStore.Model.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Repository.Common
{
    /// <summary>
    /// Defines method signatures for post repository
    /// </summary>
    public interface IPostRepository
    {
        Task<IPost> GetAsync(Guid id);
        Task<IEnumerable<IPost>> GetRangeAsync(Guid topicId,GenericFilter GenericFilter);
        Task<int> UpdateAsync(IPost post);
        Task<int> AddAsync(IPost post);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(IPost post);
    }
}
