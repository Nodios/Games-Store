using GameStore.Model.Common;
using System;
using System.Threading.Tasks;

namespace GameStore.Repository.Common
{
    public interface IInfoRepository
    {
        Task<IInfo> GetAsync(Guid id);
        Task<int> AddAsync(IInfo info);
        Task<int> UpdateAsync(IInfo info);
        Task<int> DeletAsync(IInfo info);

        
    }
}
