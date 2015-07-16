using GameStore.Model.Common;
using System;
using System.Collections.Generic;

namespace GameStore.Model
{
    /// <summary>
    /// Business logic model
    /// </summary>
    public class Post : IPost
    {
        public Guid Id { get; set; }
        public Guid GameId { get; set; }
        public string UserId { get; set; }

        public int VotesUp { get; set; }
        public int VotesDown { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }


        public virtual IGame Game { get; set; }
        public virtual IUser User { get; set; }

        // One to many, post can have many comments
        public virtual ICollection<IComment> Comments { get; set; }

    }
}
