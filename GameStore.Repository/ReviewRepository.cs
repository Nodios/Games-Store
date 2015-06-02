using AutoMapper;
using GameStore.DAL.Models;
using GameStore.Model.Common;
using GameStore.Repository.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private IRepository repository;

        /// <summary>
        /// Constructor
        /// </summary>
        public ReviewRepository(IRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Get by id
        /// </summary>
        public async Task<Model.Common.IReview> GetAsync(int id)
        {
            try
            {
                return Mapper.Map<IReview>(await repository.GetAsync<ReviewEntity>(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get all entities
        /// </summary>
        public async Task<IEnumerable<Model.Common.IReview>> GetAsync(Model.Common.IGame game)
        {
            try
            {
                return Mapper.Map<IEnumerable<IReview>>(await repository.GetRangeAsync<ReviewEntity>());
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update async
        /// </summary>
        public async Task<int> UpdateAsync(Model.Common.IReview review)
        {
            try
            {
                return await repository.UpdateAsync<ReviewEntity>(Mapper.Map<ReviewEntity>(review));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Add entity
        /// </summary>
        public async Task<int> AddAsync(IReview review)
        {
            try
            {
                return await repository.AddAsync<ReviewEntity>
                    (Mapper.Map<ReviewEntity>(review));
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Delete async
        /// </summary>
        public async Task<int> Delete(int id)
        {
            try
            {
                return await this.Delete(Mapper.Map<IReview>(
                    await repository.GetAsync<ReviewEntity>(id)));
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Delete(Model.Common.IReview review)
        {
            try
            {
                return await repository.DeleteAsync<ReviewEntity>
                    (Mapper.Map<ReviewEntity>(review));
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        
    }
}
