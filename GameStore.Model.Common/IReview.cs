
using System;
namespace GameStore.Model.Common
{
    public interface IReview
    {
        Guid Id { get; set; }
        Guid? GameId { get; set; }

        string Title { get; set; }
        string Description { get; set; }
        float Score { get; set; }
        IGame Game { get; set; }


    }
}
