

using System;
using System.ComponentModel.DataAnnotations;
namespace GameStore.DAL.Models
{
    /// <summary>
    /// Database entity
    /// </summary>
    public class CommentEntity
    {
        private DateTime date;

        public Guid Id { get; set; }
        public string UserId { get; set; }
        public Guid PostId { get; set; }
    
        [StringLength(1000, MinimumLength = 10)]
        public string Description { get; set; }
        public string UserName { get; set; }
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


        // Post and comments belong to one user
        public UserEntity User { get; set; }

        // Many comment to one post
        public virtual PostEntity Post { get; set; }




    }
}
