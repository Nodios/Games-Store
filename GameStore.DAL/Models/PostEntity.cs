
using System;
using System.Collections.Generic;

namespace GameStore.DAL.Models
{
    public class PostEntity : PostsAndComments
    {
        public string Title { get; set; }

        public Guid GameId { get; set; }
        public Guid? UserId { get; set; }

        public virtual GameEntity Game { get; set; }
        public virtual UserEntity User { get; set; }

        // One to many, post can have many comments
        public virtual ICollection<CommentEntity> Comments { get; set; }
    }
}
