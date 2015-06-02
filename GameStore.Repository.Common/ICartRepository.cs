using GameStore.Model.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Repository.Common
{
    public interface ICartRepository
    {
        Task<ICart> GetAsync(int id);
        Task<IEnumerable<ICart>> GetAsync();
        Task<int> Add(ICart cart);
        Task<int> Update(ICart cart);

        Task<int> DeleteAsync(ICart cart);
        Task<int> DeleteAsync(int id);
        

    }
}
