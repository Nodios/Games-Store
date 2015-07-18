
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GameStore.DAL.Models
{
    /// <summary>
    /// Database entity
    /// </summary>
    public class PostEntity 
    {
        private DateTime date;

        public Guid Id { get; set; }
        public string UserId { get; set; }
        public Guid TopicId { get; set; }

        public int VotesUp { get; set; }
        public int VotesDown { get; set; }
        public DateTime Date
        {
            get { return date; }
            set
            {
                if (value == null || value == DateTime.MinValue)
                    date = DateTime.Now;
                else
                    date = value;
            }
        }

        [StringLength(1000, MinimumLength = 10)]
        public string Description { get; set; }
        public string UserName { get; set; }

        // Post and comments belong to one user
        public UserEntity User { get; set; }

        // Post can have only one topic
        public virtual TopicEntity Topic { get; set; }

        // One to many, post can have many comments
        public virtual ICollection<CommentEntity> Comments { get; set; }

    } 
}
