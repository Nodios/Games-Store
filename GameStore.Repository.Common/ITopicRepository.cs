using GameStore.Common;
using GameStore.Model.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Repository.Common
{
    /// <summary>
    /// Defines method signatures for topic repository
    /// </summary>
    public interface ITopicRepository
    {
        Task<ITopic> GetAsync(Guid id);
        Task<ICollection<ITopic>> GetRangeAsync(GenericFilter filter);
        Task<ICollection<ITopic>> GetRangeAsync(GenericFilter filter, string search);
        Task<int> AddAsync(ITopic topic);
        Task<int> UpdateAsync(ITopic topic);
        Task<int> DeleteAsync(Guid id);
        
    }
}
