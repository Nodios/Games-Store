using AutoMapper;
using GameStore.Common;
using GameStore.DAL.Models;
using GameStore.Model.Common;
using GameStore.Repository.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        #region Fields and contructor

        private IRepository repository;

        /// <summary>
        /// Constructor
        /// </summary>
        public ReviewRepository(IRepository repository)
        {
            this.repository = repository;
        }

        #endregion

        #region Get 

        /// <summary>
        /// Get by id
        /// </summary>
        public async Task<Model.Common.IReview> GetAsync(Guid id)
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get collection of reviews that belong to game
        /// </summary>
        /// <param name="gameId">game FK</param>
        /// <param name="filter">filter option</param>
        /// <returns>Collection of games</returns>
        public async Task<IEnumerable<IReview>> GetAsync(Guid gameId, GameStore.Common.GenericFilter filter)
        {
            try
            {
                if (filter == null)
                    filter = new GenericFilter(1, 5);

                return Mapper.Map<IEnumerable<IReview>>(await repository.Where<ReviewEntity>()
                    .Where(g => g.GameId == gameId)
                    .OrderBy(g => g.Score)
                    .Skip((filter.PageNumber * filter.PageSize) - filter.PageSize)
                    .Take(filter.PageSize).ToListAsync());
            }
            catch (Exception)
            {
                
                throw;
            }
        }


        #endregion

        #region Update

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
        /// Update IReview
        /// </summary>
        /// <param name="review">IReview</param>
        /// <returns>IReview</returns>
        public async Task<IReview> UpdateIReviewAsync(IReview review)
        {
            try
            {
                IUnitOfWork uow = repository.CreateUnitOfWork();
                ReviewEntity result = await uow.UpdateWithAttachAsync<ReviewEntity>(AutoMapper.Mapper.Map<ReviewEntity>(review));
                await uow.CommitAsync();

                return AutoMapper.Mapper.Map<IReview>(result);

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        
        #endregion

        #region Add

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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Adds review and updates game with score
        /// </summary>
        /// <param name="review">Review</param>
        /// <returns>Review</returns>
        public async Task<IReview> AddIReviewAsync(IReview review)
        {
            try
            {
                IUnitOfWork uow = repository.CreateUnitOfWork();
                
                ReviewEntity result =  await uow.AddAsync<ReviewEntity>(Mapper.Map<ReviewEntity>(review));
                await uow.CommitAsync();

                return Mapper.Map<IReview>(result);

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }


        #endregion

        #region Delete 

        /// <summary>
        /// Delete async
        /// </summary>
        public async Task<int> Delete(Guid id)
        {
            try
            {
                return await repository.DeleteAsync<ReviewEntity>(id);
            }
            catch (Exception ex)
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
            catch (Exception ex)
            {
                throw ex;
            }
        } 

        #endregion

    }
}
