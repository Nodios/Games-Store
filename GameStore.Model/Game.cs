using GameStore.Model.Common;
using System.Collections.Generic;

namespace GameStore.Model
{
    public class Game : IGame
    {
        public int Id { get; set; }
        public int PublisherId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string OsSupport { get; set; }
        public float? ReviewScore { get; set; }

        // Many to one, Game can have one company, company can have many games
        public virtual IPublisher Publisher { get; set; }

        // One to many, game can have many posts
        public virtual ICollection<IPost> Posts { get; set; }
        public virtual ICollection<IReview> Reviews { get; set; }

        // Many to many 
        public virtual ICollection<IUser> Users { get; set; }
        public virtual ICollection<ICart> Carts { get; set; }

    }
}
