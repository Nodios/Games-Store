

namespace GameStore.DAL.Models
{
    public class CommentEntity : PostsAndComments
    {
        public int PostFK { get; set; }

        // Many comment to one post
        public virtual PostEntity Post { get; set; }
    }
}
