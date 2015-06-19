
using System;
namespace GameStore.Model.Common
{
    public interface IReview
    {
        Guid Id { get; set; }
        Guid? GameId { get; set; }

        float Score { get; set; }
        IGame Game { get; set; }
    }
}
