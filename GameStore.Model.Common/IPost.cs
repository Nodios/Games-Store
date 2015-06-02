using System.Collections.Generic;

namespace GameStore.Model.Common
{
    public interface IPost : IPostAndComment
    {
        int Title { get; set; }

        IGame Game { get; set; }

        // One to many, post can have many comments
        ICollection<IComment> Comments { get; set; }
    }
}
