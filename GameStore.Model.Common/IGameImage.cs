using System;

namespace GameStore.Model.Common
{
    public interface IGameImage
    {
        Guid Id { get; set; }
        Guid GameId { get; set; }
        byte[] Content { get; set; }
        IGame Game { get; set; }
    }
}
