
using System.Collections.Generic;

namespace GameStore.DAL.Models
{
    /// <summary>
    /// Database entity
    /// </summary>
    public class CartEntity 
    {
        // One to one, user id is also cart entity id
        public string UserId { get; set; }
      
        // One to one
        public virtual UserEntity User { get; set; }
        public virtual ICollection<GameEntity> GamesInCart { get; set; }

    }
}
