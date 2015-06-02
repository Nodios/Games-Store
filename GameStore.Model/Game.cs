using GameStore.Model.Common;
using System.Collections.Generic;

namespace GameStore.Model
{
    public class Game : IGame
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string OsSupport { get; set; }
        public float? ReviewScore { get; set; }

        // Many to one, Game can have one company, company can have many games
        public virtual ICompany Publisher { get; set; }
        public virtual IUser UserOwner { get; set; }

        // One to many, game can have many reviews and posts
        public virtual ICollection<IReview> Reviews { get; set; }
        public virtual ICollection<IPost> Posts { get; set; } 

    }
}
