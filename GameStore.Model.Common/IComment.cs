
using System;
namespace GameStore.Model.Common
{
    /// <summary>
    /// Interface for comment
    /// </summary>
    public interface IComment
    {
        Guid Id { get; set; }
        string UserId { get; set; }
        Guid PostId { get; set; }

        int VotesUp { get; set; }
        int VotesDown { get; set; }
        string Description { get; set; }
        string UserName { get; set; }
        DateTime Date { get; set; }

        // Comment belongs to single post
        IPost Post { get; set; }
        IUser User { get; set; }
    }
}
