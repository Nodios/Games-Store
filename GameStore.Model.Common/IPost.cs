using System;
using System.Collections.Generic;

namespace GameStore.Model.Common
{
    /// <summary>
    /// Interface for post
    /// </summary>
    public interface IPost : IPostAndComment
    {
        Guid TopicId { get; set; }

        string Title { get; set; }

        ITopic Topic { get; set; }

        // One to many, post can have many comments
        ICollection<IComment> Comments { get; set; }
    }
}
