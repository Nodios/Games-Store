using GameStore.Common;
using GameStore.Model.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Service.Common
{
    /// <summary>
    /// Defines method signatures for publisher service
    /// </summary>
    public interface IPublisherService
    {
        Task<IPublisher> GetAsync(Guid id);
        Task<IEnumerable<IPublisher>> GetRangeAsync(string name, GenericFilter filter);
        Task<ISupport> GetSupportAsync(Guid id);
        Task<IEnumerable<IPublisher>> GetRangeAsync(GenericFilter filter);
    }
}
