using System;

namespace GameStore.DAL.Models
{
    /// <summary>
    /// Database entity
    /// </summary>
    public class GameImageEntity : IDataEntity
    {
        public Guid Id { get; set; }
        public Guid GameId { get; set; }
        public byte[] Content { get; set; }
        public virtual GameEntity Game { get; set; }
       
    }
}
