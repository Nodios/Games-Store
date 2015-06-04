
using GameStore.Model.Common;
namespace GameStore.Model
{
    public class Review : IReview
    {
        public int Id { get; set; }
        public int? GameId { get; set; }

        public float Score { get; set; }
        public virtual IGame Game { get; set; }
    }
}
