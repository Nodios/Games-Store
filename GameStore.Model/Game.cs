using GameStore.Model.Common;
using System;
using System.Collections.Generic;

namespace GameStore.Model
{
    public class Game : IGame
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

        // Many to one, Game can have one company, company can have many games
        public virtual IPublisher Publisher { get; set; }


        // One to many, game can have many posts
        public virtual ICollection<IPost> Posts { get; set; }
        public virtual ICollection<IReview> Reviews { get; set; }
        public virtual ICollection<IGameImage> GameImages { get; set; }
        public virtual ICollection<ICart> Carts { get; set; }
    }
}
