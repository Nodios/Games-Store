
namespace GameStore.Model.Common
{
    public interface IReview
    {
        int Id { get; set; }
        int? GameId { get; set; }

        float Score { get; set; }
        IGame Game { get; set; }
    }
}
