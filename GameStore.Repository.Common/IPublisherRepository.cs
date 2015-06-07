using GameStore.Common;
using GameStore.Model.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Repository.Common
{
    public interface IPublisherRepository
    {
        Task<IPublisher> GetAsync(int id);
        Task<IPublisher> GetAsync(string name);
        Task<IEnumerable<IPublisher>> GetRangeAsync(PublisherFilter filter);

        Task<int> AddAsync(IPublisher company);
        Task<int> UpdateAsync(IPublisher company);
        Task<int> DeleteAsync(int id);
        Task<int> DeleteAsync(IPublisher company);

    }
}
