using GameStore.Common;
using GameStore.Model.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Repository.Common
{
    /// <summary>
    /// Defines method signatures for publisher repository
    /// </summary>
    public interface IPublisherRepository
    {
        Task<IPublisher> GetAsync(Guid id);
        Task<IEnumerable<IPublisher>> GetRangeAsync(string name, GenericFilter filter);
        Task<IEnumerable<IPublisher>> GetRangeAsync(GenericFilter filter);

        Task<int> AddAsync(IPublisher company);
        Task<int> UpdateAsync(IPublisher company);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(IPublisher company);

    }
}
