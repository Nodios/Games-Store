
using GameStore.Model.Common;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace GameStore.Service.Common
{
    public interface ICartService
    {
        Task<ICart> GetAsync(string userId);
        Task<ICart> UpdateAsync(ICart cart);
    }
}
