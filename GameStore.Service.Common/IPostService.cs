using GameStore.Common;
using GameStore.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Service.Common
{
    public interface IPostService
    {
        Task<IEnumerable<IPost>> GetPosts(Guid gameId, PostFilter filter);
        Task<int> AddPost(IPost post);
        Task<int> DeletePost(Guid id);
        Task<int> DeletePost(IPost post);
        Task<int> UpdatePost(IPost post);
    }
}
