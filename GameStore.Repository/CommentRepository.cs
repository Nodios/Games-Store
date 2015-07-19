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
    public class CommentRepository : ICommentRepository
    {
        private IRepository repository;

        public CommentRepository(IRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Get comment
        /// </summary>
        public async Task<Model.Common.IComment> GetAsync(Guid id)
        {
            try
            {

                return Mapper.Map<IComment>(await repository.GetAsync<CommentEntity>(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get comments
        /// </summary>
        public async Task<IEnumerable<Model.Common.IComment>> GetAsync()
        {
            try
            {
                return Mapper.Map<IEnumerable<IComment>>(await repository.GetRangeAsync<CommentEntity>());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get comments that belong to post
        /// </summary>
        /// <param name="postId">Post Fk</param>
        /// <param name="filter">Filter options</param>
        /// <returns>Collection of comments</returns>
        public async Task<IEnumerable<IComment>> GetRangeAsync(Guid postId, GenericFilter filter)
        {
            try
            {
                if (filter == null)
                    filter = new GenericFilter(1, 5);


                return Mapper.Map<IEnumerable<IComment>>(await
                    repository.Where<CommentEntity>()
                    .Where(c => c.PostId == postId)
                    .OrderBy(p => p.VotesUp)
                    .Skip((filter.PageNumber * filter.PageSize) - filter.PageSize)
                    .Take(filter.PageSize).ToListAsync());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Add comment
        /// </summary>
        public async Task<int> AddAsync(Model.Common.IComment comment)
        {
            try
            {
                return await repository.AddAsync<CommentEntity>(Mapper.Map<CommentEntity>(comment));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update comment
        /// </summary>
        /// <param name="comment">IComment</param>
        public async Task<int> UpdateAsync(Model.Common.IComment comment)
        {
            try
            {
                return await repository.UpdateAsync<CommentEntity>(Mapper.Map<CommentEntity>(comment));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Delete 
        /// </summary>
        /// <param name="comment">Icomment</param>
        /// <returns>1 if succuess, 0 otherwise</returns>
        public async Task<int> DeleteAsync(Model.Common.IComment comment)
        {
            try
            {
                return await repository.DeleteAsync<CommentEntity>(Mapper.Map<CommentEntity>(comment));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Delete comment entity by id
        /// </summary>
        public async Task<int> DeleteAsync(Guid id)
        {
            try
            {
                return await this.DeleteAsync
                    (Mapper.Map<IComment>(await repository.GetAsync<CommentEntity>(id)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
