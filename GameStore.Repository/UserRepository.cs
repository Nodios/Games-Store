using AutoMapper;
using GameStore.DAL;
using GameStore.DAL.Models;
using GameStore.Model.Common;
using GameStore.Repository.Common;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Repository
{
    public class UserRepository : IUserRepository
    {
        private IRepository repository;
        private PasswordHasher hasher;
        private UserManager<UserEntity> userManager;

        /// <summary>
        /// Constructor
        /// </summary>
        public UserRepository(IRepository repository)
        {
            this.repository = repository;
            hasher = new PasswordHasher();
            userManager = new UserManager<UserEntity>
                (new UserStore<UserEntity>(new GamesStoreContext()));
        }

        /// <summary>
        ///  Get by id
        /// </summary>
        public async Task<Model.Common.IUser> GetAsync(Guid id)
        {
            try
            {
                return Mapper.Map<Model.Common.IUser>(await repository.GetAsync<UserEntity>(id));
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
                return Mapper.Map<IEnumerable<Model.Common.IUser>>(await repository.GetRangeAsync<UserEntity>());
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        /// <summary>
        /// Find user by username and password
        /// </summary>
        public async Task<Model.Common.IUser> FindUserAsync(string username, string password)
        {
            try
            {
                UserEntity user = await userManager.FindAsync(username, password);
                return Mapper.Map<Model.Common.IUser>(user);
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
                return await this.DeleteAsync(Mapper.Map<Model.Common.IUser>
                    (await repository.GetAsync<UserEntity>(id)));
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        /// <summary>
        /// Registers adds user
        /// </summary>
        /// <param name="user"></param>
        /// <returns>True if success, false otherwise</returns>
        public async Task<bool> RegisterUser(Model.Common.IUser user)
        {
            try
            {
                IdentityResult result = await userManager.CreateAsync(Mapper.Map<UserEntity>(user), user.Password);
                return result.Succeeded;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public Task<IUnitOfWork> CreateUnitOfWork()
        {
            try
            {
                return Task.FromResult<IUnitOfWork>(repository.CreateUnitOfWork());
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
    }
}
