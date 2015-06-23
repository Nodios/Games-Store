using System;
using System.Collections.Generic;

namespace GameStore.Model.Common
{
    public interface IUser
    {

        string UserName { get; set; }
        string Password { get; set; }
        string ConfirmPassword { get; set; }
        string PasswordHash { get; set; }
        string Email { get; set; }

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
