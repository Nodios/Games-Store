using GameStore.Model.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Repository.Common
{
    public interface ICartRepository
    {
        Task<ICart> GetAsync(Guid id);
        Task<IEnumerable<ICart>> GetAsync();
        Task<int> Add(ICart cart);
        Task<int> Update(ICart cart);

        Task<int> DeleteAsync(ICart cart);
        Task<int> DeleteAsync(Guid id);
        

    }
}
