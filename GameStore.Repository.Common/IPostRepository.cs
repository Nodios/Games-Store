using GameStore.Model.Common;
using System.Threading.Tasks;

namespace GameStore.Repository.Common
{
    public interface IPostRepository
    {
        Task<IPost> GetAsnyc(int id);
        Task<int> UpdateAsync(IPost post);
        Task<int> AddAsync(IPost post);
        Task<int> DeleteAsync(int id);
        Task<int> DeleteAsync(IPost post);
    }
}
