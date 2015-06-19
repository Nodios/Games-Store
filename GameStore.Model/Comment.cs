using GameStore.Model.Common;
using System;

namespace GameStore.Model
{
    public class Comment : IComment
    {
        public Guid Id { get; set; }
        public Guid PostId { get; set; }

        public int VotesUp { get; set; }
        public int VotesDown { get; set; }
        public string Description { get; set; }

        // Many comment to one post
        public virtual IPost Post { get; set; }

    }
}
