
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.DAL.Models
{
    public class UserEntity : IdentityUser
    {
        [Required]
        [StringLength(50, ErrorMessage="Password should be between 6 and 50 characthers", MinimumLength=6)]
        [Display(Name="Password")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage="Password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

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
