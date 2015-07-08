
using GameStore.Model.Common;
using System.Threading.Tasks;
namespace GameStore.Service.Common
{
    public interface ICartService
    {
        Task<ICart> GetAsync(string userId);
        Task<int> UpdateAsync(ICart cart);
        Task<ICart> UpdateCartAsync(ICart cart, bool deletePreviousCart = false);
    }
}
