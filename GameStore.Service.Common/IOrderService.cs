using GameStore.Common;
using GameStore.Model.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Service.Common
{
    /// <summary>
    /// Defines method signatures for order service
    /// </summary>
    public interface IOrderService
    {
        Task<ICollection<IOrder>> GetAsync(string userId, GenericFilter filter);
        Task<IOrder> AddAsync(IOrder order);
        Task<int> DeleteAsync(Guid id);
    }
}
