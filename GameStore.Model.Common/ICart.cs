using System.Collections.Generic;

namespace GameStore.Model.Common
{
    public interface ICart
    {
        int Id { get; set; }
        
        // One to one
        IUser User { get; set; }

        // One to many
        ICollection<IGame> GamesInCart { get; set; }
    }
}
