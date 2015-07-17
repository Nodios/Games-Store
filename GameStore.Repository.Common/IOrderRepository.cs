using GameStore.Common;
using GameStore.Model.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Repository.Common
{
    /// <summary>
    /// Defines method signatures for order repository
    /// </summary>
    public interface IOrderRepository
    {
        Task<IOrder> GetAsync(Guid id);
        Task<ICollection<IOrder>> GetRangeAsync(string userId, GenericFilter filter);
        Task<IOrder> AddAsync(IOrder order);
        Task<IOrder> UpdateAsync(IOrder order);
        Task<int> DeleteAsync(Guid id);

    }
}
