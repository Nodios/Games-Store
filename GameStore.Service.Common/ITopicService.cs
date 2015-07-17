using GameStore.Common;
using GameStore.Model.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Service.Common
{
    /// <summary>
    /// Provides method signatures for topic service
    /// </summary>
    public interface ITopicService
    {
        Task<ITopic> GetAsync(Guid id);
        Task<ICollection<ITopic>> GetRangeAsync(GenericFilter filter);
        Task<int> AddAsync(ITopic topic);   
    }
}
