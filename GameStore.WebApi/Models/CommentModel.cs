using System;

namespace GameStore.WebApi.Models
{
    /// <summary>
    /// Comment class
    /// </summary>
    public class CommentModel
    {
        public Guid Id { get; set; }
        public Guid PostId { get; set; }
        public string UserId { get; set; }

        public int VotesUp { get; set; }
        public int VotesDown { get; set; }
        public string Description { get; set; }
        public string UserName { get; set; }
        public DateTime Date { get; set; }
    }
}