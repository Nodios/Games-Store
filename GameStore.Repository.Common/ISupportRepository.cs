using GameStore.Model.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Repository.Common
{
    public interface ISupportRepository
    {
        Task<ISupport> GetAsync(int id);
        Task<IEnumerable<ISupport>> GetAsync();
        Task<int> AddAsync(ISupport support);
        Task<int> UpdateAsync(ISupport support);
        Task<int> DeleteAsync(int id);
        Task<int> DeleteAsync(ISupport support);
    }
}
