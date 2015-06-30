using System;
using System.Collections.Generic;

namespace GameStore.Model.Common
{
    public interface IGame
    {
        Guid Id { get; set; }
        Guid PublisherId { get; set; }

        string Name { get; set; }
        string Description { get; set; }
        string OsSupport { get; set; }
        float? ReviewScore { get; set; }
        string Genre { get; set; }
        double Price { get; set; }

        // Many to one, Game can have one company, company can have many games
        IPublisher Publisher { get; set; }

        // One to many, game can have many reviews and posts
        ICollection<IReview> Reviews { get; set; }
        ICollection<IPost> Posts { get; set; }
        ICollection<IUser> Users { get; set; }

    }
}
