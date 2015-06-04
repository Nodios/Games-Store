
using System.Collections.Generic;

namespace GameStore.DAL.Models
{
    public class GameEntity : IDataEntity
    {
        public int Id { get; set; }
        public int PublisherId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string OsSupport { get; set; }
        public float? ReviewScore { get; set; }

        // Many to one, Game can have one company, company can have many games
        public virtual PublisherEntity Publisher { get; set; }


        // One to many, game can have many posts
        public virtual ICollection<PostEntity> Posts { get; set; }
        public virtual ICollection<ReviewEntity> Reviews { get; set; }
       
        // Many to many 
        public virtual ICollection<UserEntity> Users { get; set; }
        public virtual ICollection<CartEntity> Carts { get; set; }

    }
}
