using AutoMapper;
using GameStore.Common;
using GameStore.DAL.Models;
using GameStore.Model.Common;
using GameStore.Repository.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IRepository repository;

        public OrderRepository(IRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Get order by id
        /// </summary>
        public async Task<Model.Common.IOrder> GetAsync(Guid id)
        {
            try
            {
                IOrder order = Mapper.Map<IOrder>(await repository.GetAsync<OrderEntity>(id));

                if (order == null)
                    throw new Exception("Order doesn't exist in database.");

                return order;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Get collection of orders that belong to user
        /// </summary>
        /// <param name="userId">User FK</param>
        /// <param name="filter">Fitler options</param>
        /// <returns>Collection of orders</returns>
        public async Task<ICollection<Model.Common.IOrder>> GetRangeAsync(string userId, GenericFilter filter)
        {
            try
            {
                if (filter == null)
                    filter = new GenericFilter(1, 5);

                return Mapper.Map<ICollection<IOrder>>(await repository.Where<OrderEntity>()
                    .Where(c => c.UserId == userId)
                    .OrderBy(c => c.Surname)
                    .Skip((filter.PageNumber * filter.PageSize) - filter.PageSize)
                    .Take(filter.PageSize).ToListAsync());

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Add new order
        /// </summary>
        /// <param name="order">Order to add</param>
        /// <returns>Added order</returns>
        public async Task<Model.Common.IOrder> AddAsync(Model.Common.IOrder order)
        {
            try
            {
                IUnitOfWork uow = repository.CreateUnitOfWork();

                OrderEntity entity = Mapper.Map<OrderEntity>(order);
                Task<OrderEntity> orderResult = uow.AddAsync<OrderEntity>(entity);
                await uow.CommitAsync();

                return Mapper.Map<IOrder>(orderResult.Result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Update order
        /// </summary>
        public async Task<Model.Common.IOrder> UpdateAsync(Model.Common.IOrder order)
        {
            try
            {
                IUnitOfWork uow = repository.CreateUnitOfWork();

                Task<OrderEntity> result = uow.UpdateWithAddAsync<OrderEntity>(Mapper.Map<OrderEntity>(order));
                await uow.CommitAsync();

                return Mapper.Map<IOrder>(result.Result);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Delete order
        /// </summary>
        public async Task<int> DeleteAsync(Guid id)
        {
            try
            {
                int result = await repository.DeleteAsync<OrderEntity>(id);

                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
