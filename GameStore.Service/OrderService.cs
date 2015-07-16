using GameStore.Common;
using GameStore.Model.Common;
using GameStore.Repository.Common;
using GameStore.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Service
{
    public class OrderService : IOrderService
    {
        IOrderRepository repository;

        public OrderService(IOrderRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ICollection<IOrder>> GetAsync(string userId, GenericFilter filter)
        {
            return await repository.GetRangeAsync(userId, filter);
        }

        public async Task<Model.Common.IOrder> AddAsync(Model.Common.IOrder order)
        {
            return await repository.AddAsync(order);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await repository.DeleteAsync(id);
        }
    }
}
