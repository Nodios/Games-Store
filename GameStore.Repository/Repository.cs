using GameStore.DAL;
using GameStore.Repository.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Linq;

namespace GameStore.Repository
{
    public class Repository : IRepository
    {
        #region Fields

        private readonly IGamesStoreContext context;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor , takes context
        /// </summary>
        public Repository(IGamesStoreContext context)
        {
            if (context == null)
                throw new ArgumentNullException("Context cannot be null");

            this.context = context;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets singe entity
        /// </summary>
        /// <param name="id">Entity id</param>
        /// <returns>Entity or null</returns>
        public Task<T> GetAsync<T>(int id) where T : class
        {
            return context.Set<T>().FindAsync(id);
        }

        /// <summary>
        /// Geta all entites
        /// </summary>
        /// <returns>List or null</returns>
        public async Task<IEnumerable<T>> GetRangeAsync<T>() where T : class
        {
            return await context.Set<T>().ToListAsync();
        }

        /// <summary>
        /// Find entity 
        /// </summary>
        /// <param name="match">Expression</param>
        /// <returns>Entity or null</returns>
        public Task<T> GetAsync<T>(Expression<Func<T, bool>> match) where T : class
        {
            return context.Set<T>().FirstAsync(match);
        }

        /// <summary>
        /// Find enties
        /// </summary>
        /// <param name="match">expression</param>
        /// <returns>List of entites or null</returns>
        public async Task<IEnumerable<T>> GetRangeAsync<T>
            (Expression<Func<T, bool>> match) where T : class
        {
            return await context.Set<T>().Where(match).ToListAsync();
        }

        /// <summary>
        /// Adds entity 
        /// </summary>
        /// <param name="entity">Entity to add</param>
        /// <returns>Entity</returns>
        public async Task<int> AddAsync<T>(T entity) where T : class
        {
            try
            {
                context.Set<T>().Add(entity);
                return await context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Adds collection of entites
        /// </summary>
        /// <param name="listOfEntities">collection</param>
        /// <returns>collection</returns>
        public async Task<int> AddAsync<T>(IEnumerable<T> listOfEntities) where T : class
        {
            try
            {
                context.Set<T>().AddRange(listOfEntities);
                return await context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update entity
        /// </summary>
        public async Task<int> UpdateAsync<T>(T entity) where T : class
        {
            try
            {
                context.Set<T>().Attach(entity);
                context.Entry<T>(entity).State = EntityState.Modified;

                return await context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Deletes entity
        /// </summary>
        public async Task<int> DeleteAsync<T>(T entity) where T : class
        {
            try
            {
                context.Set<T>().Remove(entity);
                return await context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Deletes entity
        /// </summary>
        public async Task<int> DeleteAsync<T>(int id) where T : class
        {
            T entity = await GetAsync<T>(id);
            if (entity == null)
            {
                throw new Exception("Entity does not exist");
            }
            return await DeleteAsync<T>(entity);
        }

        #endregion
    }
}
