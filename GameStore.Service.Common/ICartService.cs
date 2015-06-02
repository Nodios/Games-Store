using GameStore.Model.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Common
{
    public interface ICartService
    {
        Task<ICart> GetAsync(int id);
        Task<int> AddAsync(ICart cart);
        Task<int> UpdateAsync(ICart cart);
        Task<int> DeleteAsync(ICart cart);

        Task<ICart> AddGameAsync(ICart cart, IGame game);
        Task<ICart> AddGameAsync(ICart cart, IEnumerable<IGame> games);
        Task<ICart> RemoveGameAsync(ICart cart, IGame game);
        Task<ICart> RemoveGameAsync(ICart cart, IEnumerable<IGame> games);

    }
}
