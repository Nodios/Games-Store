using System.Collections.Generic;

namespace GameStore.WebApi.Models
{
    public class CartModel
    {
        public string UserId { get; set; }
        public virtual IList<GameModel> GamesInCart { get; set; }
    }
}