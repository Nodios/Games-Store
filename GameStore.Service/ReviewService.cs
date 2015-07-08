﻿using GameStore.Model.Common;
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

        public async Task<int> UpdateAsync(Model.Common.IReview review)
        {
            return await repository.UpdateAsync(review);
        }

        public async Task<int> DeleteAsync(Model.Common.IReview review)
        {
            return await repository.Delete(review);
        }
    }
}
