using System;

namespace GameStore.WebApi.Models
{
    public class GameImageModel
    {
        public Guid Id { get; set; }
        public Guid GameId { get; set; }
        public byte[] Content { get; set; }
    }
}