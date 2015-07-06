using AutoMapper;
using GameStore.Common;
using GameStore.DAL.Models;
using GameStore.Model.Common;
using GameStore.Repository.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
                return await repository.UpdateAsync(Mapper.Map<CartEntity>(cart));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ICart> UpdateCartAsync(ICart cart)
        {
            try
            {
                IUnitOfWork uow = repository.CreateUnitOfWork();
                CartEntity result = await uow.UpdateAsync<CartEntity>(Mapper.Map<CartEntity>(cart));
                await uow.CommitAsync();
                return Mapper.Map<ICart>(result);
            }
            catch (Exception)
            {
                
                throw;
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
