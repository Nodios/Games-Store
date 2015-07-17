using GameStore.Common;
using GameStore.Model.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Service.Common
{
    /// <summary>
    /// Defines method signatures for games service
    /// </summary>
    public interface IGamesService
    {
        Task<IGame> GetAsync(Guid id);
        Task<IEnumerable<IGame>> GetRangeAsync(string name, GenericFilter filter);
        Task<IEnumerable<IGame>> GetRangeAsync(GenericFilter filter = null);
        Task<IEnumerable<IGame>> GetRangeAsync(Guid publisherId, GenericFilter filter = null);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(params Guid[] id);
    }
}
