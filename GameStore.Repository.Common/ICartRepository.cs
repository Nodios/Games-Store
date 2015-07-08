using GameStore.Model.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Repository.Common
{
    public interface ICartRepository
    {
        Task<ICart> GetAsync(string userId);
        Task<IEnumerable<ICart>> GetAsync();
        Task<int> AddAsync(ICart cart);
        Task<int> UpdateAsync(ICart cart);
        Task<ICart> UpdateCartAsync(ICart cart, bool deletePreviousCart);
        Task<int> DeleteAsync(ICart cart);
        Task<int> DeleteAsync(Guid id);
        

    }
}
