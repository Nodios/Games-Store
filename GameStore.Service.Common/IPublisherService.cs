using GameStore.Model.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Common
{
    public interface IPublisherService
    {
        Task<IPublisher> GetAsync(int id);
        Task<IPublisher> GetAsync(string name);
        Task<ISupport> GetSupportAsync(int id);
        Task<IEnumerable<IPublisher>> GetRangeAsync();
    }
}
