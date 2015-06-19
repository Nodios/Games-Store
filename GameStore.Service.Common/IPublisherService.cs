using GameStore.Common;
using GameStore.Model.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Common
{
    public interface IPublisherService
    {
        Task<IPublisher> GetAsync(Guid id);
        Task<IEnumerable<IPublisher>> GetRangeAsync(string name);
        Task<ISupport> GetSupportAsync(Guid id);
        Task<IEnumerable<IPublisher>> GetRangeAsync(PublisherFilter filter);
    }
}
