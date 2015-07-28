using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;

namespace GameStore.WindowsApp.Model
{
    /// <summary>
    /// Cart entity
    /// </summary>
    public class Cart : ObservableObject
    {

        private string userId;
        private ICollection<Game> gamesInCart;

        /// <summary>
        /// Get user id
        /// </summary>
        public string UserId
        {
            get { return this.userId; }
        }

        /// <summary>
        /// Gets and sets games in cart
        /// </summary>
        public ICollection<Game> GamesInCart
        {
            get { return this.gamesInCart; }
            set { Set(() => this.GamesInCart, ref gamesInCart, value); }
           
        }

        /// <summary>
        /// Initialies new cart
        /// </summary>
        /// <param name="id">Cart id</param>
        public Cart(string id)
        {
            userId = id;
            gamesInCart = new List<Game>();
        }
    }
}
