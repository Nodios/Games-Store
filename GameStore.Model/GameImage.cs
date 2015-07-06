using GameStore.Model.Common;
using System;

namespace GameStore.Model
{
    public class GameImage : IGameImage
    {
        public Guid Id { get; set; }
        public Guid GameId { get; set; }
        public byte[] Content { get; set; }
        public virtual IGame Game { get; set; }
    }
}
