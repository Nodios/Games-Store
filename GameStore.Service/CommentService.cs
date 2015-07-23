using GameStore.Repository.Common;
using GameStore.Service.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Service
{
    /// <summary>
    /// Comment service
    /// </summary>
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository repository;

        /// <summary>
        /// The constructor
        /// </summary>
        /// <param name="repository">ICommentRepository interface user</param>
        public CommentService(ICommentRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Get collection of comments that belong to post
        /// </summary>
        /// <param name="postId">Post id to search by</param>
        /// <param name="filter">Filter options</param>
        /// <returns>IEnumerable of comments</returns>
        public async Task<IEnumerable<Model.Common.IComment>> GetRangeAsync(Guid postId, GameStore.Common.GenericFilter filter)
        {
            return await repository.GetRangeAsync(postId, filter);
        }

        /// <summary>
        /// Add comment
        /// </summary>
        /// <param name="comment">Comment to add</param>
        /// <returns>The number of objects written to the underlying database.</returns>
        public async Task<int> AddAsync(Model.Common.IComment comment)
        {
            return await repository.AddAsync(comment);
        }

        /// <summary>
        /// Update comment async
        /// </summary>
        /// <param name="comment">Comment to update</param>
        /// <returns>The number of objects written to the underlying database.</returns>
        public async Task<int> UpdateAsync(Model.Common.IComment comment)
        {
            return await repository.UpdateAsync(comment);
        }

        /// <summary>
        /// Delete commetn async
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>The number of objects written to the underlying database.</returns>
        public async Task<int> DeleteAsync(Guid id)
        {
            return await repository.DeleteAsync(id);
        }
    }
}
