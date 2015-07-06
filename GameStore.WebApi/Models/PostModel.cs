using System;

namespace GameStore.WebApi.Models
{
    public class PostModel
    {
        public Guid Id { get; set; }
        public int VotesUp { get; set; }
        public int VotesDown { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public Guid GameId { get; set; }
        public Guid? UserId { get; set; }
    }
}