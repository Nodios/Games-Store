using GameStore.Repository.Common;
using GameStore.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task<Model.Common.ICart> GetAsync(string userId)
        {
            return await repository.GetAsync(userId);
        }

        public async Task<Model.Common.ICart> UpdateAsync(Model.Common.ICart cart)
        {
            return await repository.UpdateCartAsync(cart);
        }
    }
}
