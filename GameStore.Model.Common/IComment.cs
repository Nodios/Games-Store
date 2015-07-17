
using System;
namespace GameStore.Model.Common
{
    /// <summary>
    /// Interface for comment
    /// </summary>
    public interface IComment : IPostAndComment
    {
        Guid PostId { get; set; }

        // Comment belongs to single post
        IPost Post { get; set; }
    }
}
