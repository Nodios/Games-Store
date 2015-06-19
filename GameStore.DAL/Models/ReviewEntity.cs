

using System;
namespace GameStore.DAL.Models
{
    public class ReviewEntity : IDataEntity
    {
        public Guid Id { get; set; }
        public Guid? GameId { get; set; }

        public float Score { get; set; }
        public GameEntity Game { get; set; }
    }
}
