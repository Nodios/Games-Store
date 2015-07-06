
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.DAL.Models
{
    public class UserEntity : IdentityUser
    {
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
        
        [Index(IsUnique=true)]
        public override string UserName { get; set; }

        // One to one 
        public virtual InfoEntity Info { get; set; }
        public virtual CartEntity Cart { get; set; }
       

        // One to many
        public virtual ICollection<CommentEntity> Comments { get; set; }
        public virtual ICollection<PostEntity> Posts { get; set; }
        public virtual ICollection<ReviewEntity> Reviews { get; set; }     
      
        // many to many
        public virtual ICollection<GameEntity> Games { get; set; }
    }
}
