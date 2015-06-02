using GameStore.Model.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Repository.Common
{
    public interface ICommentRepository
    {
        Task<IComment> GetAsync(int id);
        Task<IEnumerable<IComment>> GetAsync();
        

        Task<int> AddAsync(IComment comment);
        Task<int> UpdateAsync(IComment comment);
        Task<int> DeleteAsync(IComment comment);
        Task<int> DeleteAsync(int id);
    }
}
