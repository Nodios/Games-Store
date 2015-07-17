
using System;
namespace GameStore.Model.Common
{
    /// <summary>
    /// Interface for review
    /// </summary>
    public interface IReview
    {
        Guid Id { get; set; }
        Guid GameId { get; set; }
        string UserId { get; set; }

        string Author { get; set; }
        string Title { get; set; }
        string Description { get; set; }
        float Score { get; set; }
        IGame Game { get; set; }
        IUser User { get; set; }


    }
}
