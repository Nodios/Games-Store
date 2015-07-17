using GameStore.Common;
using GameStore.Model.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Repository.Common
{
    /// <summary>
    /// Defines method signatures for game repository
    /// </summary>
    public interface IGameRepository 
    {
        Task<IGame> GetAsync(Guid id);
        Task<IEnumerable<IGame>> GetRangeAsync(string name,GenericFilter filter);
        Task<IEnumerable<IGame>> GetRangeAsync(GenericFilter filter = null);
        Task<IEnumerable<IGame>> GetRangeAsync(Guid publisherId,GenericFilter filter = null);

        Task<int> UpdateAsync(IGame game);
        Task<int> AddAsync(IGame game);
        Task<int> DeleteAsync(IGame game);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(params Guid[] id);

    }
}
