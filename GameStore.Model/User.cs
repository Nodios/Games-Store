using GameStore.Model.Common;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;

namespace GameStore.Model
{
    public class User : IdentityUser, IUser
    {
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        // One to one 
        public virtual IInfo Info { get; set; }
        public virtual ICart Cart { get; set; }

        // One to many
        public virtual ICollection<IGame> Games { get; set; }
        public virtual ICollection<IComment> Comments { get; set; }
        public virtual ICollection<IPost> Posts { get; set; }
        public virtual ICollection<IReview> Reviews { get; set; }           
    }
}
