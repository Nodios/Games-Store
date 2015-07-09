using AutoMapper;
using GameStore.DAL.Models;
using GameStore.Model.Common;
using GameStore.Repository.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data;
using GameStore.DAL;
using System.Data.Entity.Infrastructure;

namespace GameStore.Repository
{
    /// <summary>
    /// Cart repository
    /// </summary>
    public class CartRepository : ICartRepository
    {
        private IRepository repository;

        #region Constructors

        public CartRepository(IRepository repository)
        {
            this.repository = repository;
        }

        #endregion

        #region Get
		
        /// <summary>
        /// Gets ICart by id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>Icart</returns>
        public async Task<Model.Common.ICart> GetAsync(string userId)
        {
            try
            {
                return Mapper.Map<ICart>(await repository.GetAsync<CartEntity>(c => c.UserId == userId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets all ICart
        /// </summary>
        /// <returns>List of carts</returns>
        public async Task<IEnumerable<Model.Common.ICart>> GetAsync()
        {
            try
            {
                return Mapper.Map<IEnumerable<ICart>>(await repository.GetRangeAsync<IEnumerable<CartEntity>>());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

	#endregion

        #region Add
		
        /// <summary>
        /// Add cart
        /// </summary>
        /// <param name="cart">Icart</param>
        /// <returns>Added Icart</returns>
        public async Task<int> AddAsync(Model.Common.ICart cart)
        {
            try
            {
                return await repository.AddAsync<CartEntity>(Mapper.Map<CartEntity>(cart));
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

	#endregion

        #region Update

        /// <summary>
        /// Updates cart
        /// </summary>
        /// <param name="cart">Icart entity</param>
        /// <returns>Icart</returns>
        public async Task<int> UpdateAsync(Model.Common.ICart cart)
        {
            try
            {
                int result = await repository.UpdateWithAddAsync(Mapper.Map<CartEntity>(cart));
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// NOTE: Deletes previous cart, adds new one
        /// </summary>
        /// <param name="cart">Cart item</param>
        /// <param name="deleteOldEntries">If delete, deletes old entries</param>
        /// <returns>Saves cart item</returns>
        public async Task<ICart> UpdateCartAsync(ICart cart, bool deletePreviousCart)
        {
            try
            {
                
                IUnitOfWork uow = repository.CreateUnitOfWork();
                Task<CartEntity> result = null;

                if (deletePreviousCart)
                {
                    int deleted = await uow.DeleteAsync<CartEntity>(c => c.GamesInCart == cart.GamesInCart);
                 //   if(deleted != 0)
                     //   result = uow.AddAsync<CartEntity>(AutoMapper.Mapper.Map<CartEntity>(cart));
                }
                else
                {
                    result = uow.UpdateWithAddAsync<CartEntity>(AutoMapper.Mapper.Map<CartEntity>(cart));
                }
  
                await uow.CommitAsync();
                ICart entity = Mapper.Map<ICart>(result.Result);
                return entity;

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        #endregion

        #region Delete

        /// <summary>
        /// Deletes cart
        /// </summary>
        public Task<int> DeleteAsync(Model.Common.ICart cart)
        {
            try
            {
                return repository.DeleteAsync<CartEntity>(Mapper.Map<CartEntity>(cart));
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Deletes cart
        /// </summary>
        public async Task<int> DeleteAsync(Guid id)
        {
            try
            {
                return await this.DeleteAsync(Mapper.Map<ICart>
                    (await repository.GetAsync<CartEntity>(id)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
