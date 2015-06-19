using GameStore.Model.Common;
using System;
using System.Collections.Generic;

namespace GameStore.Model
{
    public class Cart : ICart
    {
        public Guid Id { get; set; }
        
        // One to one
        public virtual IUser User { get; set; }

        // One to many
        public virtual ICollection<IGame> GamesInCart { get; set; }
    }
}
