
using System.Collections.Generic;

namespace GameStore.DAL.Models
{
    public class UserEntity : IDataEntity
    {
        public int Id { get; set; }

        public string Username { get; set; }

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
