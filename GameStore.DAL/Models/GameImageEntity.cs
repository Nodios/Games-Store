using System;

namespace GameStore.DAL.Models
{
    public class GameImageEntity
    {
        public Guid Id { get; set; }
        public Guid GameId { get; set; }
        public byte[] Content { get; set; }
        public virtual GameEntity Game { get; set; }
       
    }
}
