
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.DAL.Models
{
    public class GameEntity 
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
        public virtual PublisherEntity Publisher { get; set; }
       
        // One to many, game can have many posts
        public virtual ICollection<PostEntity> Posts { get; set; }
        public virtual ICollection<ReviewEntity> Reviews { get; set; }
        public virtual ICollection<GameImageEntity> GameImages { get; set; }

        public virtual ICollection<CartEntity> Carts { get; set; }

    }
}
