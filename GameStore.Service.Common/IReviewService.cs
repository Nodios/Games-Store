using GameStore.Common;
using GameStore.Model.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Service.Common
{
    public interface IReviewService
    {
        Task<IEnumerable<IReview>> GetAsync(Guid gameId, GenericFilter filter);
        Task<IReview> AddAsync(IReview review);
        Task<IReview> UpdateAsync(IReview review);
        Task<int> DeleteAsync(Guid id);
    }
}
