using System.Collections.Generic;

namespace GameStore.Model.Common
{
    public interface IPost : IPostAndComment
    {
        string Title { get; set; }

        int GameId { get; set; }
        int? UserId { get; set; }

        IGame Game { get; set; }
        IUser User { get; set; }

        // One to many, post can have many comments
        ICollection<IComment> Comments { get; set; }
    }
}
