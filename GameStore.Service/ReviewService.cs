using GameStore.Model.Common;
using GameStore.Repository.Common;
using GameStore.Service.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Service
{
    public class ReviewService : IReviewService
    {
        IReviewRepository repository;

        public ReviewService(IReviewRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<IReview>> GetAsync(Guid gameId, GameStore.Common.GenericFilter filter)
        {
            return await repository.GetAsync(gameId, filter);
        }

        public async Task<Model.Common.IReview> AddAsync(Model.Common.IReview review)
        {
            return await repository.AddIReviewAsync(review);
        }

        public async Task<IReview> UpdateAsync(Model.Common.IReview review)
        {
            return await repository.UpdateIReviewAsync(review);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await repository.Delete(id);
        }
    }
}
