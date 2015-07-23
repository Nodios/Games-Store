using GameStore.Common;
using GameStore.Repository.Common;
using GameStore.Service.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Service
{
    public class PostService : IPostService
    {
 
        public readonly IPostRepository postRepository;

        #region Constructors

        public PostService(IPostRepository repository)
        {
            if (repository == null)
                throw new ArgumentNullException("repository cannot be null");

            postRepository = repository;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Get collection of posts
        /// </summary>
        /// <param name="gameId">Game id</param>
        /// <param name="filter">Filter</param>
        /// <returns>Collection of posts</returns>
        public Task<IEnumerable<Model.Common.IPost>> GetPosts(Guid gameId, GenericFilter filter)
        {
            return postRepository.GetRangeAsync(gameId, filter);
        }

        /// <summary>
        /// Add new post
        /// </summary>
        public Task<int> AddPost(Model.Common.IPost post)
        {
            return postRepository.AddAsync(post);
        }

        /// <summary>
        /// Delete post
        /// </summary>
        public Task<int> DeletePost(Model.Common.IPost post)
        {
            return postRepository.DeleteAsync(post);
        }

        /// <summary>
        /// Delete post
        /// </summary>
        public Task<int> DeletePost(Guid id)
        {
            return postRepository.DeleteAsync(id);
        }

        /// <summary>
        /// Update post
        /// </summary>
        public Task<int> UpdatePost(Model.Common.IPost post)
        {
            return postRepository.UpdateAsync(post);
        } 

        #endregion
    }
}
