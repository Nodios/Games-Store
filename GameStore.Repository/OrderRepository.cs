using AutoMapper;
using GameStore.DAL.Models;
using GameStore.Model.Common;
using GameStore.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Repository
{
    public class OrderRepository : IOrderRepository
    {
        IRepository repository;

        public OrderRepository(IRepository repository)
        {
            this.repository = repository;
        }

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

        public async Task<ICollection<Model.Common.IOrder>> GetRangeAsync(string userId)
        {
            try
            {
                ICollection<IOrder> orders = Mapper.Map<ICollection<IOrder>>
                    (await repository.GetRangeAsync<IOrder>(c => c.UserId == userId));

                if (orders.Count == 0)
                    throw new Exception("Couldn't find any orders for user.");

                return orders;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public async Task<Model.Common.IOrder> AddAsync(Model.Common.IOrder order)
        {
            try
            {
                IUnitOfWork uow = repository.CreateUnitOfWork();

                OrderEntity entity = Mapper.Map<OrderEntity>(order);
                Task<OrderEntity> orderResult =  uow.AddAsync<OrderEntity>(entity);
                await uow.CommitAsync();

                return Mapper.Map<IOrder>(orderResult.Result);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

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
