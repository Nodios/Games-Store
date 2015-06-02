

namespace GameStore.DAL.Models
{
    public class ReviewEntity : IDataEntity
    {
        public int Id { get; set; }

        public int? FKGame { get; set; }
        public float Score { get; set; }
        public GameEntity Game { get; set; }
    }
}
