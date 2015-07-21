using GameStore.WindowsApp.Model;
using GameStore.WindowsApp.Utilities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.WindowsApp.Service.Common
{
    /// <summary>
    /// Provides signature methods for games service
    /// </summary>
    public interface IGamesService
    {
        Task<Game> GetAsync(Guid id);
        Task<IEnumerable<Game>> GetRangeAsync(string name, GenericFilter filter);
        Task<IEnumerable<Game>> GetRangeAsync(GenericFilter filter = null);
        Task<IEnumerable<Game>> GetRangeAsync(Guid publisherId, GenericFilter filter = null);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(params Guid[] id);
    }
}
