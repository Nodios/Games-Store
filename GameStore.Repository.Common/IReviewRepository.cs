﻿using GameStore.Model.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Repository.Common
{
    public interface IReviewRepository
    {
        Task<IReview> GetAsync(Guid id);
        Task<IEnumerable<IReview>> GetAsync(IGame game);
        Task<int> AddAsync(IReview review);
        Task<int> UpdateAsync(IReview review);
        Task<int> Delete(Guid id);
        Task<int> Delete(IReview review);
    }
}
