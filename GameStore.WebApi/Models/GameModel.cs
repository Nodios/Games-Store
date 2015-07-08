using System;
using System.Collections.Generic;

namespace GameStore.WebApi.Models
{
    /// <summary>
    /// Game class
    /// </summary>
    public class GameModel
    {
        public Guid Id { get; set; }
        public Guid PublisherId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string OsSupport { get; set; }
        public float? ReviewScore { get; set; }
        public string Genre { get; set; }
        public double Price { get; set; }
        public bool IsInCart { get; set; }


    }
}