using GameStore.Model.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Repository.Common
{
    public interface IGameRepository 
    {
        Task<IGame> GetAsync(int id);
        Task<IGame> GetAsync(string name);
        Task<IEnumerable<IGame>> GetRangeAsync();
        Task<IEnumerable<IGame>> GetRangeAsync(int publisherId);

        Task<int> UpdateAsync(IGame game);
        Task<int> AddAsync(IGame game);
        Task<int> DeleteAsync(IGame game);
        Task<int> DeleteAsync(int id);

    }
}
