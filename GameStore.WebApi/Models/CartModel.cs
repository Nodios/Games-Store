using System.Collections.Generic;

namespace GameStore.WebApi.Models
{
    public class CartModel
    {
        public string UserId { get; set; }
        public virtual IEnumerable<GameModel> GamesInCart { get; set; }
    }
}