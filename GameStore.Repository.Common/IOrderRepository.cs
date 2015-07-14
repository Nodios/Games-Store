using GameStore.Model.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Repository.Common
{
    public interface IOrderRepository
    {
        Task<IOrder> GetAsync(Guid id);
        Task<ICollection<IOrder>> GetRangeAsync(string userId);
        Task<IOrder> AddAsync(IOrder order);
        Task<IOrder> UpdateAsync(IOrder order);
        Task<int> DeleteAsync(Guid id);

    }
}
