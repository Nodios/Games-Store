using GameStore.Model.Common;
using System.Threading.Tasks;

namespace GameStore.Repository.Common
{
    public interface IInfoRepository
    {
        Task<IInfo> GetAsync(int id);
        Task<int> AddAsync(IInfo info);
        Task<int> UpdateAsync(IInfo info);
        Task<int> DeletAsync(IInfo info);

        
    }
}
