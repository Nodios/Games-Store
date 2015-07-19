
using System;
using System.ComponentModel.DataAnnotations;
namespace GameStore.DAL.Models
{
    /// <summary>
    /// Provides implementation that is shared between multiple entites
    /// </summary>
    public class PostsAndComments : IDataEntity
    {
        public PostsAndComments()
        {
            if (Id == null)
                Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string UserId { get; set; }

        public int VotesUp { get; set; }
        public int VotesDown { get; set; }
        public DateTime Date { get; set; }

        [StringLength(1000,MinimumLength=10)]
        public string Description { get; set; }
        public string UserName { get; set; }

        // Post and comments belong to one user
        public UserEntity User { get; set; }
    }
}
