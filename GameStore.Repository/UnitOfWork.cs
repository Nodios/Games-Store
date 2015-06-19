using System;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using GameStore.Repository.Common;
using GameStore.DAL;

namespace GameStore.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        protected IGamesStoreContext DbContext { get; private set; }

        public UnitOfWork(IGamesStoreContext context)
        {
            if(context == null)
            {
                throw new ArgumentNullException("Context cannot be null");
            }

            DbContext = context;
        }

        /// <summary>
        /// Adds entity, commit should be called afterwards to save changes
        /// </summary>
        /// <returns>T entity</returns>
        public virtual Task<T> AddAsync<T>(T entity) where T : class
        {
            try
            {
                DbEntityEntry dbEntity = DbContext.Entry(entity);
                if(dbEntity.State != EntityState.Detached)
                {
                    dbEntity.State = EntityState.Added;
                }
                else
                {
                   DbContext.Set<T>().Add(entity);
                }
                return Task.FromResult(dbEntity.Entity as T);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Updates entity, commit should be called afterwards to save changes
        /// </summary>
        /// <returns>T entity</returns>
        public virtual Task<T> UpdateAsync<T>(T entity) where T : class
        {
            try
            {
                DbEntityEntry entry = DbContext.Entry(entity);
                if (entry.State == EntityState.Detached)
                {
                    DbContext.Set<T>().Attach(entity);
                    DbContext.Entry<T>(entity).State = EntityState.Modified;
                }
                else
                {
                    entry.State = EntityState.Modified;
                }

                return Task.FromResult(entry.Entity as T);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Deletes entity,commit should be called afterwards to save changes
        /// </summary>
        public virtual Task<int> DeleteAsync<T>(T entity) where T : class
        {
            try
            {
                DbEntityEntry entityEntry = DbContext.Entry(entity);
                if (entityEntry.State != EntityState.Deleted)
                {
                    entityEntry.State = EntityState.Deleted;
                }
                return Task.FromResult(1);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Delete entity, commit should be called afterwards to save changes
        /// </summary>
        public Task<int> DeleteAsync<T>(Guid id) where T : class
        {
            try
            {
                T entity = DbContext.Set<T>().Find(id);
                if (entity == null)
                {
                    return Task.FromResult(0);
                }
                return DeleteAsync<T>(entity);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public async Task<int> CommitAsync()
        {
            return await DbContext.SaveChangesAsync();
        }

        #region Dispose implementation

        public void Dispose()
        {
            DbContext.Dispose();
        }

        #endregion
    }
}
