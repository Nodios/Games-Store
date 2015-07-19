using GameStore.Repository.Common;
using GameStore.Service.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Service
{
    public class CommentService : ICommentService
    {
        ICommentRepository repository;

        public CommentService(ICommentRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<Model.Common.IComment>> GetRangeAsync(Guid postId, GameStore.Common.GenericFilter filter)
        {
            return await repository.GetRangeAsync(postId, filter);
        }

        public async Task<int> AddAsync(Model.Common.IComment comment)
        {
            return await repository.AddAsync(comment);
        }
    }
}
