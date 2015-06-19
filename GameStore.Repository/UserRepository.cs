using AutoMapper;
using GameStore.DAL.Models;
using GameStore.Model.Common;
using GameStore.Repository.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Repository
{
    public class UserRepository : IUserRepository
    {
        private IRepository repository;

        /// <summary>
        /// Constructor
        /// </summary>
        public UserRepository(IRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        ///  Get by id
        /// </summary>
        public async Task<Model.Common.IUser> GetAsync(Guid id)
        {
            try
            {
                return Mapper.Map<IUser>(await repository.GetAsync<UserEntity>(id));
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        /// <summary>
        /// Get all entites
        /// </summary>
        public async Task<IEnumerable<Model.Common.IUser>> GetAsync(System.Linq.Expressions.Expression<Func<Model.Common.IUser, bool>> match)
        {
            try
            {
                return Mapper.Map<IEnumerable<IUser>>(await repository.GetRangeAsync<UserEntity>());
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        /// <summary>
        /// Add user
        /// </summary>
        public async Task<int> AddAsync(Model.Common.IUser user)
        {
            try
            {
                return await repository.AddAsync<UserEntity>(Mapper.Map<UserEntity>(user));
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        /// <summary>
        /// Update user
        /// </summary>
        public async Task<int> UpdateAsync(Model.Common.IUser user)
        {
            try
            {
                return await this.repository.UpdateAsync<UserEntity>(Mapper.Map<UserEntity>(user));
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        /// <summary>
        /// Delete user
        /// </summary>
        public async Task<int> DeleteAsync(Model.Common.IUser user)
        {
            try
            {
                return await repository.DeleteAsync<UserEntity>(Mapper.Map<UserEntity>(user));
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        /// <summary>
        /// Delete by id
        /// </summary>
        public async Task<int> DeleteAsync(Guid id)
        {
            try
            {
                return await this.DeleteAsync(Mapper.Map<IUser>
                    (await repository.GetAsync<UserEntity>(id)));
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
    }
}
