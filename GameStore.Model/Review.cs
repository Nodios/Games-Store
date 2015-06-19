
using GameStore.Model.Common;
using System;
namespace GameStore.Model
{
    public class Review : IReview
    {
        public Guid Id { get; set; }
        public Guid? GameId { get; set; }

        public float Score { get; set; }
        public virtual IGame Game { get; set; }
    }
}
