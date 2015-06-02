using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameStore.Model.Common
{
    public interface IGame
    {
        int Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        string OsSupport { get; set; }
        float? ReviewScore { get; set; }

        // Many to one, Game can have one company, company can have many games
        ICompany Publisher { get; set; }
        IUser UserOwner { get; set; }

        // One to many, game can have many reviews and posts
        ICollection<IReview> Reviews { get; set; }
        ICollection<IPost> Posts { get; set; } 

    }
}
