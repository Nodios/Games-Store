using GameStore.Model.Common;
using System.Collections.Generic;

namespace GameStore.Model
{
    /// <summary>
    /// Business logic model
    /// </summary>
    public class Cart : ICart
    {
        public string UserId { get; set; }
        
        // One to one
        public virtual IUser User { get; set; }

        // One to many
        public virtual ICollection<IGame> GamesInCart { get; set; }
    }
}
