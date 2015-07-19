using GameStore.Common;
using GameStore.Model.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Service.Common
{
    public interface ICommentService
    {
        Task<IEnumerable<IComment>> GetRangeAsync(Guid postId, GenericFilter filter);
        Task<int> AddAsync(IComment comment);
    }
}
