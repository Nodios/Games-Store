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
        #region Proporties

        /// <summary>
        /// Gets post repository
        /// </summary>
        public IPostRepository PostRepository { get; private set; } 

        #endregion

        #region Constructors

        public PostService(IPostRepository repository)
        {
            if (repository == null)
                throw new ArgumentNullException("repository cannot be null");

            PostRepository = repository;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Get collection of posts
        /// </summary>
        /// <param name="gameId">Game id</param>
        /// <param name="filter">Filter</param>
        /// <returns>Collection of posts</returns>
        public Task<IEnumerable<Model.Common.IPost>> GetPosts(int gameId, PostFilter filter)
        {
            return PostRepository.GetRangeAsync(gameId, filter);
        }

        /// <summary>
        /// Add new post
        /// </summary>
        public Task<int> AddPost(Model.Common.IPost post)
        {
            return PostRepository.AddAsync(post);
        }

        /// <summary>
        /// Delete post
        /// </summary>
        public Task<int> DeletePost(Model.Common.IPost post)
        {
            return PostRepository.DeleteAsync(post);
        }

        /// <summary>
        /// Delete post
        /// </summary>
        public Task<int> DeletePost(int id)
        {
            return PostRepository.DeleteAsync(id);
        }

        /// <summary>
        /// Update post
        /// </summary>
        public Task<int> UpdatePost(Model.Common.IPost post)
        {
            return PostRepository.UpdateAsync(post);
        } 

        #endregion
    }
}
