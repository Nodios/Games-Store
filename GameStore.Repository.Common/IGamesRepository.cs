using GameStore.Model.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Repository.Common
{
    public interface IGamesRepository 
    {
        Task<IGame> GetAsync(int id);
        Task<IEnumerable<IGame>> GetRangeAsync();

        Task<int> UpdateAsync(IGame game);
        Task<int> AddAsync(IGame game);
        Task<int> DeleteAsync(IGame game);
        Task<int> DeleteAsync(int id);

    }
}
