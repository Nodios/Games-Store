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
    /// <summary>
    /// Topic repository
    /// </summary>
    public class TopicRepository : ITopicRepository
    {
        private readonly IRepository repository;

        /// <summary>
        /// The constructor
        /// </summary>
        /// <param name="repository">IRepository member</param>
        public TopicRepository(IRepository repository)
        {
            this.repository = repository;
        }

        #region GET

        /// <summary>
        /// Get topic  by id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>ITopic</returns>
        public async Task<Model.Common.ITopic> GetAsync(Guid id)
        {
            try
            {
                return Mapper.Map<ITopic>(await repository.GetAsync<TopicEntity>(id));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Get collection of topics
        /// </summary>
        /// <param name="filter">Filter</param>
        /// <returns>Collection of topics</returns>
        public async Task<ICollection<Model.Common.ITopic>> GetRangeAsync(GameStore.Common.GenericFilter filter)
        {
            try
            {
                if (filter == null)
                    filter = new GenericFilter(1, 5);

                return Mapper.Map<ICollection<ITopic>>(await repository.Where<TopicEntity>()
                    .OrderBy(t => t.Title)
                    .Skip((filter.PageNumber * filter.PageSize) - filter.PageSize)
                    .Take(filter.PageSize).ToListAsync());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Get collection of topics
        /// </summary>
        /// <param name="filter">Filter with pagenumber and size</param>
        /// <param name="search">Search string</param>
        /// <returns>Topics collection</returns>
        public async Task<ICollection<ITopic>> GetRangeAsync(GenericFilter filter, string search)
        {
            try
            {
                if (filter == null)
                    filter = new GenericFilter(1, 5);

                return Mapper.Map<ICollection<ITopic>>(await repository.Where<TopicEntity>()
                    .Where(t => t.Title.Contains(search))
                    .OrderBy(t => t.Title)
                    .Skip((filter.PageNumber * filter.PageSize) - filter.PageSize)
                    .Take(filter.PageSize).ToListAsync());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        } 

        #endregion

        /// <summary>
        /// Add new topic
        /// </summary>
        /// <param name="topic">ITopic implemented entity</param>
        /// <returns>The number of objects written to the underlying database.</returns>
        public Task<int> AddAsync(Model.Common.ITopic topic)
        {
            try
            {
                return repository.AddAsync<TopicEntity>(Mapper.Map<TopicEntity>(topic));
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        /// <summary>
        /// Update async
        /// </summary>
        /// <param name="topic">Topic to update</param>
        /// <returns>The number of objects written to the underlying database.</returns>
        public Task<int> UpdateAsync(Model.Common.ITopic topic)
        {
            try
            {
                return repository.UpdateAsync<TopicEntity>(Mapper.Map<TopicEntity>(topic));
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        /// <summary>
        /// Delete async
        /// </summary>
        /// <param name="id">Id to delete by</param>
        /// <returns>The number of objects written to the underlying database.</returns>
        public async Task<int> DeleteAsync(Guid id)
        {
            try
            {
                return await repository.DeleteAsync<TopicEntity>(id);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
    }
}
