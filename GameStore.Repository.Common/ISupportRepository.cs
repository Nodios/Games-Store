using GameStore.Model.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Repository.Common
{
    /// <summary>
    /// Defines method signatures for support repository
    /// </summary>
    public interface ISupportRepository
    {
        Task<ISupport> GetAsync(Guid id);
        Task<IEnumerable<ISupport>> GetAsync();
        Task<int> AddAsync(ISupport support);
        Task<int> UpdateAsync(ISupport support);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(ISupport support);
    }
}
