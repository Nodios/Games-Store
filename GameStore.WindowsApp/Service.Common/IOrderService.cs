using GameStore.WindowsApp.Model;
using GameStore.WindowsApp.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.WindowsApp.Service.Common
{
    public interface IOrderService
    {
        Task<ICollection<Order>> GetAsync(string userId);
        Task<Order> AddAsync(Order order);
    }
}
