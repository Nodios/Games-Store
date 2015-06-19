using GameStore.Model.Common;
using System;
using System.Collections.Generic;

namespace GameStore.Model
{
    public class User : IUser
    {
        public Guid Id { get; set; }
        public string Username { get; set; }

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
