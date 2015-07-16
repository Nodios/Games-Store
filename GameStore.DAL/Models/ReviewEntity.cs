

using System;
namespace GameStore.DAL.Models
{
    /// <summary>
    /// Database entity
    /// </summary>
    public class ReviewEntity : IDataEntity
    {
        public Guid Id { get; set; }
        public Guid GameId { get; set; }
        public string UserId { get; set; }

        public string Author { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public float Score { get; set; }
        public UserEntity User { get; set; }
        public GameEntity Game { get; set; }
    }
}
