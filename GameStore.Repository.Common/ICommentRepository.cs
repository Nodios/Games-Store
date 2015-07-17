using GameStore.Model.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Repository.Common
{
    /// <summary>
    /// Defines method signatures for comment repository
    /// </summary>
    public interface ICommentRepository
    {
        Task<IComment> GetAsync(Guid id);
        Task<IEnumerable<IComment>> GetAsync();
        

        Task<int> AddAsync(IComment comment);
        Task<int> UpdateAsync(IComment comment);
        Task<int> DeleteAsync(IComment comment);
        Task<int> DeleteAsync(Guid id);
    }
}
