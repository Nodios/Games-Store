using GameStore.Common;
using GameStore.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Service.Common
{
    public interface IOrderService
    {
        Task<ICollection<IOrder>> GetAsync(string userId, GenericFilter filter);
        Task<IOrder> AddAsync(IOrder order);
        Task<int> DeleteAsync(Guid id);
    }
}
