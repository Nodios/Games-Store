
using System;
using System.Collections.Generic;

namespace GameStore.DAL.Models
{
    public class CartEntity : IDataEntity
    {
       
        public Guid Id { get; set; }
      
        // One to one
        public virtual UserEntity User { get; set; }
        public virtual ICollection<GameEntity> Games { get; set; }

    }
}
