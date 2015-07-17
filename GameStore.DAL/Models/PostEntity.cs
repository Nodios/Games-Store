
using System;
using System.Collections.Generic;

namespace GameStore.DAL.Models
{
    /// <summary>
    /// Database entity
    /// </summary>
    public class PostEntity : PostsAndComments
    {    
        /// <summary>
        /// Fk to topic
        /// </summary>
        public Guid TopicId { get; set; }

        public string Title { get; set; }

        // Post can have only one topic
        public virtual TopicEntity Topic { get; set; }

        // One to many, post can have many comments
        public virtual ICollection<CommentEntity> Comments { get; set; }
    } 
}
