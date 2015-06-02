
using System.Collections.Generic;

namespace GameStore.DAL.Models
{
    public class PostEntity : PostsAndComments
    {
        public string Title { get; set; }

        public int? GameFK { get; set; }
        public int? UserFK { get; set; }

        public virtual GameEntity Game { get; set; }
        public virtual UserEntity User { get; set; }

        // One to many, post can have many comments
        public virtual ICollection<CommentEntity> Comments { get; set; }
    }
}
