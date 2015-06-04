﻿

namespace GameStore.DAL.Models
{
    public class CommentEntity : PostsAndComments
    {
        public int PostId { get; set; }

        // Many comment to one post
        public virtual PostEntity Post { get; set; }
    }
}
