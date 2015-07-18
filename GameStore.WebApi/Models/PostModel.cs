using System;

namespace GameStore.WebApi.Models
{
    public class PostModel
    {
        public Guid Id { get; set; }
        public Guid TopicId { get; set; }
        public Guid UserId { get; set; }

        public int VotesUp { get; set; }
        public int VotesDown { get; set; }
        public string Description { get; set; }
        public string UserName { get; set; }
        public DateTime Date { get; set; }
    }
}