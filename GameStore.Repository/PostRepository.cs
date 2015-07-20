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
    public class PostRepository : IPostRepository
    {
        private IRepository repository;

        public PostRepository(IRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Get by id
        /// </summary>
        public async Task<Model.Common.IPost> GetAsync(Guid id)
        {
            try
            {
                return Mapper.Map<IPost>(await repository.GetAsync<PostEntity>(id));
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        /// <summary>
        /// Get range async
        /// </summary>
        public async Task<IEnumerable<IPost>> GetRangeAsync(Guid topicId,GenericFilter filter)
        {
            try
            {
                if (filter == null)
                    filter = new GenericFilter(1, 5);

                return Mapper.Map<IEnumerable<IPost>>(await 
                    repository.Where<PostEntity>()
                    .Where(p => p.TopicId == topicId)
                    .OrderByDescending(p => p.Date)
                    .Skip((filter.PageNumber * filter.PageSize) - filter.PageSize)
                    .Take(filter.PageSize)
                    .ToListAsync());
                    
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update post
        /// </summary>
        public async Task<int> UpdateAsync(Model.Common.IPost post)
        {
            try
            {
                return await repository.UpdateAsync<PostEntity>(Mapper.Map<PostEntity>(post));
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        /// <summary>
        /// Add post
        /// </summary>
        public async Task<int> AddAsync(Model.Common.IPost post)
        {
            try
            {
                return await repository.AddAsync<PostEntity>(Mapper.Map<PostEntity>(post));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Delete async
        /// </summary>
        /// <param name="id">Id</param>
        public async Task<int> DeleteAsync(Guid id)
        {
            try
            {
                return await repository.DeleteAsync<PostEntity>(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Delete async
        /// </summary>
        /// <param name="post">Post</param>
        public async Task<int> DeleteAsync(Model.Common.IPost post)
        {
            try
            {
                return await repository.DeleteAsync<PostEntity>(Mapper.Map<PostEntity>(post));
            }
            catch (Exception ex)
            {

                throw ex;
            } throw new NotImplementedException();
        }
    }
}
