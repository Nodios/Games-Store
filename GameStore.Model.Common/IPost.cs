using System;
using System.Collections.Generic;

namespace GameStore.Model.Common
{
    public interface IPost : IPostAndComment
    {
        Guid GameId { get; set; }
        string UserId { get; set; }

        string Author { get; set; }

        IGame Game { get; set; }
        IUser User { get; set; }

        // One to many, post can have many comments
        ICollection<IComment> Comments { get; set; }
    }
}
