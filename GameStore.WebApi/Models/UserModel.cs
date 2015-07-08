using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace GameStore.WebApi.Models
{

    public class UserModel : IdentityUser
    {
        public UserModel()
        {
            Id = Guid.NewGuid().ToString();    
        }

        public override string Id
        {
            get
            {
                return base.Id;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                    base.Id = Guid.NewGuid().ToString();
                else
                    base.Id = value;
            }
        }
        public virtual CartModel Cart { get; set; }
        

    }
}