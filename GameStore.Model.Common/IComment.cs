
namespace GameStore.Model.Common
{
    public interface IComment : IPostAndComment
    {
        // Many comment to one post
        IPost Post { get; set; }
    }
}
