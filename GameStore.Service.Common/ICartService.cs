
using GameStore.Model.Common;
using System;
using System.Threading.Tasks;
namespace GameStore.Service.Common
{
    /// <summary>
    /// Defines method signatures for cart service
    /// </summary>
    public interface ICartService
    {
        Task<ICart> GetAsync(string userId);
        Task<int> UpdateAsync(ICart cart);
        Task<ICart> UpdateCartAsync(ICart cart, bool deletePreviousCart = false);
        Task<int> Delete(Guid id);
    }
}
