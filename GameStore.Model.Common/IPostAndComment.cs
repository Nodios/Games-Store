
using System;
namespace GameStore.Model.Common
{
    public interface IPostAndComment
    {
        Guid Id { get; set; }
        int VotesUp { get; set; }
        int VotesDown { get; set; }
        string Description { get; set; }
    }
}
