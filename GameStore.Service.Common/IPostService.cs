using GameStore.Common;
using GameStore.Model.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Service.Common
{
    /// <summary>
    /// Defines method signatures for post service
    /// </summary>
    public interface IPostService
    {
        Task<IEnumerable<IPost>> GetPosts(Guid gameId, GenericFilter filter);
        Task<int> AddPost(IPost post);
        Task<int> DeletePost(Guid id);
        Task<int> DeletePost(IPost post);
        Task<int> UpdatePost(IPost post);
    }
}
