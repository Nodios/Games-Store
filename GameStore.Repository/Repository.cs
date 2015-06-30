using GameStore.DAL;
using GameStore.Repository.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System.Data.Entity.Infrastructure;

namespace GameStore.Repository
{
    public class Repository : IRepository
    {
        #region Fields

        protected IGamesStoreContext Context { get; private set; }
        protected IUnitOfWorkFactory UnitOfWorkFactory { get; private set; }
   
        #endregion

        #region Constructors

        /// <summary>
        /// Constructor , takes context
        /// </summary>
        public Repository(IGamesStoreContext context, IUnitOfWorkFactory unitOfWorkFactory)
        {
            if (context == null)
                throw new ArgumentNullException("Context cannot be null");

            this.Context = context;
            this.UnitOfWorkFactory = unitOfWorkFactory;
        }

        #endregion

        #region Methods

        public IUnitOfWork CreateUnitOfWork()
        {
            return UnitOfWorkFactory.CreateUnitOfWork();
        }

        /// <summary>
        /// Gets singe entity
        /// </summary>
        /// <param name="id">Entity id</param>
        /// <returns>Entity or null</returns>
        public Task<T> GetAsync<T>(Guid id) where T : class
        {
            return Context.Set<T>().FindAsync(id);
        }

        /// <summary>
        /// Get where
        /// </summary>
        public IQueryable<T> Where<T>() where T : class
        {
            return Context.Set<T>();
        }

        /// <summary>
        /// Geta all entites
        /// </summary>
        /// <returns>List or null</returns>
        public async Task<IEnumerable<T>> GetRangeAsync<T>() where T : class
        {
            return await Context.Set<T>().ToListAsync();
        }

        /// <summary>
        /// Find entity 
        /// </summary>
        /// <param name="match">Expression</param>
        /// <returns>Entity or null</returns>
        public Task<T> GetAsync<T>(Expression<Func<T, bool>> match) where T : class
        {
            return Context.Set<T>().FirstAsync(match);
        }

        /// <summary>
        /// Find enties
        /// </summary>
        /// <param name="match">expression</param>
        /// <returns>List of entites or null</returns>
        public async Task<IEnumerable<T>> GetRangeAsync<T>
            (Expression<Func<T, bool>> match) where T : class
        {
            return await Context.Set<T>().Where(match).ToListAsync();
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
                Context.Set<T>().Add(entity);
                return await Context.SaveChangesAsync();
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
                Context.Set<T>().AddRange(listOfEntities);
                return await Context.SaveChangesAsync();
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
                DbEntityEntry dbEntityEntry = Context.Entry(entity);
                Context.Set<T>().Add(entity);

                return await Context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update entity
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <param name="entity">Entity to update</param>
        /// <param name="proportiesToUpdate">Entite proporties to update</param>
        /// <returns>Save changes async</returns>
        public async Task<int> UpdateAsync<T>(T entity, params Expression<Func<T, object>>[] proportiesToUpdate) where T : class
        {
            try
            {
                Context.Set<T>().Add(entity);
                foreach (var property in proportiesToUpdate)
                {
                    Context.Entry<T>(entity).Property(property).IsModified = true;
                }

                return await Context.SaveChangesAsync();
            }
            catch (Exception ex)
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
                Context.Set<T>().Remove(entity);
                return await Context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Deletes entity
        /// </summary>
        public async Task<int> DeleteAsync<T>(Guid id) where T : class
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
