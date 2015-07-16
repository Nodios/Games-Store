

using System;
namespace GameStore.DAL.Models
{
    /// <summary>
    /// Database entity
    /// </summary>
    public class CommentEntity : PostsAndComments
    {
        public Guid PostId { get; set; }

        // Many comment to one post
        public virtual PostEntity Post { get; set; }
    }
}
