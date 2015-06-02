
namespace GameStore.Model.Common
{
    public interface IPostAndComment
    {
        int Id { get; set; }
        int VotesUp { get; set; }
        int VotesDown { get; set; }
        string Description { get; set; }
    }
}
