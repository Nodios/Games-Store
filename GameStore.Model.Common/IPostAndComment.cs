
using System;
namespace GameStore.Model.Common
{
    /// <summary>
    /// Interface with id, votesup and down implementation, and description
    /// </summary>
    public interface IPostAndComment
    {
        Guid Id { get; set; }
        string UserId { get; set; }

        int VotesUp { get; set; }
        int VotesDown { get; set; }
        string Description { get; set; }
        string UserName { get; set; }

        IUser User { get; set; }
    }
}
