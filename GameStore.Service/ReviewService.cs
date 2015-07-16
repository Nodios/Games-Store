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

        /// <summary>
        /// Get all reviews for game
        /// </summary>
        /// <param name="gameId">Game id</param>
        /// <param name="filter">Filter options</param>
        /// <returns>Collection of games that belong to game with given id</returns>
        public async Task<IEnumerable<IReview>> GetAsync(Guid gameId, GameStore.Common.GenericFilter filter)
        {
            return await repository.GetAsync(gameId, filter);
        }

        /// <summary>
        /// Adds new review
        /// </summary>
        public async Task<Model.Common.IReview> AddAsync(Model.Common.IReview review)
        {
            return await repository.AddIReviewAsync(review);
        }

        /// <summary>
        /// Updates given review
        /// </summary>
        public async Task<IReview> UpdateAsync(Model.Common.IReview review)
        {
            return await repository.UpdateIReviewAsync(review);
        }

        /// <summary>
        /// Deletes review by id
        /// </summary>
        public async Task<int> DeleteAsync(Guid id)
        {
            return await repository.Delete(id);
        }
    }
}
