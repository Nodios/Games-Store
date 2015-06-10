using GameStore.Common;
using GameStore.Model.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Common
{
    public interface IGamesService
    {
        Task<IGame> GetAsync(int id);
        Task<IGame> GetAsync(string name);
        Task<IEnumerable<IGame>> GetRangeAsync(GameFilter filter = null);
        Task<IEnumerable<IGame>> GetRangeAsync(int publisherId);
    }
}
