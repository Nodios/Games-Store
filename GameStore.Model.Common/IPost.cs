using System;
using System.Collections.Generic;

namespace GameStore.Model.Common
{
    /// <summary>
    /// Interface for post
    /// </summary>
    public interface IPost
    {
        Guid Id { get; set; }
        Guid TopicId { get; set; }
        string UserId { get; set; }

        int VotesUp { get; set; }
        int VotesDown { get; set; }
        string Description { get; set; }
        string UserName { get; set; }
        DateTime Date { get; set; }

        IUser User { get; set; }
        ITopic Topic { get; set; }

        // One to many, post can have many comments
        ICollection<IComment> Comments { get; set; }
    }
}
