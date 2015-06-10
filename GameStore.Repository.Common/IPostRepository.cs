using GameStore.Common;
using GameStore.Model.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Repository.Common
{
    public interface IPostRepository
    {
        Task<IPost> GetAsync(int id);
        Task<IEnumerable<IPost>> GetRangeAsync(int gameId,PostFilter postFilter);
        Task<int> UpdateAsync(IPost post);
        Task<int> AddAsync(IPost post);
        Task<int> DeleteAsync(int id);
        Task<int> DeleteAsync(IPost post);
    }
}
