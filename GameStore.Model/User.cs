using GameStore.Model.Common;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;

namespace GameStore.Model
{
    public class User : IdentityUser, IUser
    {
        public override string Id
        {
            get
            {
                return base.Id;
            }
            set
            {
                if (String.IsNullOrEmpty(Id))
                    base.Id = Guid.NewGuid().ToString();
                else
                    base.Id = value;
            }
        }

        // One to one 
        public virtual IInfo Info { get; set; }
        public virtual ICart Cart { get; set; }

        // One to many
        public virtual ICollection<IComment> Comments { get; set; }
        public virtual ICollection<IPost> Posts { get; set; }
        public virtual ICollection<IReview> Reviews { get; set; }

    }
}
