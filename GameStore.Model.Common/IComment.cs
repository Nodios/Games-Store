
namespace GameStore.Model.Common
{
    public interface IComment : IPostAndComment
    {
        int PostId { get; set; }

        // Comment belongs to single post
        IPost Post { get; set; }
    }
}
