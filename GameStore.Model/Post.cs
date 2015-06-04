using GameStore.Model.Common;
using System.Collections.Generic;

namespace GameStore.Model
{
    public class Post : IPost
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int? UserId { get; set; }

        public int VotesUp { get; set; }
        public int VotesDown { get; set; }
        public string Description { get; set; }
        public int Title { get; set; }

        public virtual IGame Game { get; set; }
        public virtual IUser User { get; set; }

        // One to many, post can have many comments
        public virtual ICollection<IComment> Comments { get; set; }
    }
}
