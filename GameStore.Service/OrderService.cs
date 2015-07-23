using GameStore.Common;
using GameStore.Model.Common;
using GameStore.Repository.Common;
using GameStore.Service.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository repository;

        public OrderService(IOrderRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Gets orders made by user
        /// </summary>
        /// <param name="userId">User id</param>
        /// <param name="filter">Filter options</param>
        /// <returns>Collection of orders</returns>
        public async Task<ICollection<IOrder>> GetAsync(string userId, GenericFilter filter)
        {
            return await repository.GetRangeAsync(userId, filter);
        }

        /// <summary>
        /// Add new order, return newly added order
        /// </summary>
        public async Task<Model.Common.IOrder> AddAsync(Model.Common.IOrder order)
        {
            return await repository.AddAsync(order);
        }

        /// <summary>
        /// Delete order by id
        /// </summary>
        public async Task<int> DeleteAsync(Guid id)
        {
            return await repository.DeleteAsync(id);
        }
    }
}
