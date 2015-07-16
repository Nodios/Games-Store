using GameStore.Model.Common;
using GameStore.Repository.Common;
using GameStore.Service.Common;
using System;
using System.Threading.Tasks;

namespace GameStore.Service
{
    public class CartService : ICartService
    {
        ICartRepository repository;

        public CartService(ICartRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Get cart by user id
        /// </summary>
        public async Task<Model.Common.ICart> GetAsync(string userId)
        {
            return await repository.GetAsync(userId);
        }


        /// <summary>
        /// Update
        /// </summary>
        public async Task<int> UpdateAsync(ICart cart)
        {
            return await repository.UpdateAsync(cart);
        }

        /// <summary>
        /// Updates and return cart
        /// </summary>
        /// <param name="cart">Cart</param>
        /// <param name="deletePreviousCart">Deletes previous items in cart if true</param>
        /// <returns>Neawly created cart</returns>
        public async Task<ICart> UpdateCartAsync(Model.Common.ICart cart, bool deletePreviousCart = false)
        {
            return await repository.UpdateCartAsync(cart, deletePreviousCart);
        }

        /// <summary>
        /// Delete cart
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>1 if success, 0 otherwise</returns>
        public async Task<int> Delete(Guid id)
        {
            return await repository.DeleteAsync(id);
        }
    }
}
