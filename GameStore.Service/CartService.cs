using GameStore.Model.Common;
using GameStore.Repository.Common;
using Service.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Service
{
    public class CartService : ICartService
    {
        public ICartRepository Repository { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository">ICartRepsotiory instance</param>
        public CartService(ICartRepository repository)
        {
            if (repository == null)
                throw new ArgumentNullException();

            Repository = repository;
        }

        /// <summary>
        /// Get by id
        /// </summary>
        public Task<ICart> GetAsync(int id)
        {
            return Repository.GetAsync(id);
        }

        /// <summary>
        /// Add new cart
        /// </summary>
        public Task<int> AddAsync(ICart cart)
        {
            if (cart == null)
                throw new ArgumentNullException();

            return Repository.Add(cart);
        }

        /// <summary>
        /// Update
        /// </summary>
        public Task<int> UpdateAsync(ICart cart)
        {
            if (cart == null)
                throw new ArgumentNullException();

            return Repository.Update(cart);
        }

        /// <summary>
        /// Delete
        /// </summary>
        public Task<int> DeleteAsync(ICart cart)
        {
            if (cart == null)
                throw new ArgumentNullException();

            return Repository.DeleteAsync(cart);
        }


        public Task<ICart> AddGameAsync(ICart cart, IGame game)
        {
            throw new NotImplementedException();
            
        }


        public Task<Model.Common.ICart> AddGameAsync(ICart cart, IEnumerable<IGame> games)
        {
            throw new NotImplementedException();
        }

        public Task<Model.Common.ICart> RemoveGameAsync(ICart cart, IGame game)
        {
            throw new NotImplementedException();
        }

        public Task<Model.Common.ICart> RemoveGameAsync(ICart cart, IEnumerable<IGame> games)
        {
            throw new NotImplementedException();
        }
    }
}
