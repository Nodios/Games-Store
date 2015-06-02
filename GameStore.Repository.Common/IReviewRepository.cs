using GameStore.Model.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Repository.Common
{
    public interface IReviewRepository
    {
        Task<IReview> GetAsync(int id);
        Task<IEnumerable<IReview>> GetAsync(IGame game);
        Task<int> AddAsync(IReview review);
        Task<int> UpdateAsync(IReview review);
        Task<int> Delete(int id);
        Task<int> Delete(IReview review);
    }
}
