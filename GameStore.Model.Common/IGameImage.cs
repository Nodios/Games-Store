using System;

namespace GameStore.Model.Common
{
    /// <summary>
    /// Interface for game image
    /// </summary>
    public interface IGameImage
    {
        Guid Id { get; set; }
        Guid GameId { get; set; }
        byte[] Content { get; set; }
        IGame Game { get; set; }
    }
}
