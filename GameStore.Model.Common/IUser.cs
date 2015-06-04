using System.Collections.Generic;

namespace GameStore.Model.Common
{
    public interface IUser
    {
        int Id { get; set; }

        string Username { get; set; }

        // One to one 
        IInfo Info { get; set; }
        ICart Cart { get; set; }

        // One to many
        ICollection<IGame> Games { get; set; }
        ICollection<IComment> Comments { get; set; }
        ICollection<IPost> Posts { get; set; }
        ICollection<IReview> Reviews { get; set; }           
    }
}
