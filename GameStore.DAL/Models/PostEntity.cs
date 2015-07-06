
using System;
using System.Collections.Generic;

namespace GameStore.DAL.Models
{
    public class PostEntity : PostsAndComments
    {
        public string Author { get; set; }

        public Guid GameId { get; set; }
        public string UserId { get; set; }

        public virtual GameEntity Game { get; set; }
        public virtual UserEntity User { get; set; }

        // One to many, post can have many comments
        public virtual ICollection<CommentEntity> Comments { get; set; }
    } 
}
