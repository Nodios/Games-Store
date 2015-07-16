
using GameStore.Model.Common;
using System;
namespace GameStore.Model
{
    /// <summary>
    /// Business logic model
    /// </summary>
    public class Review : IReview
    {
        public Guid Id { get; set; }
        public Guid GameId { get; set; }
        public string UserId { get; set; }

        public string Author { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public float Score { get; set; }
        public virtual IGame Game { get; set; }
        public virtual IUser User { get; set; }
    }
}
