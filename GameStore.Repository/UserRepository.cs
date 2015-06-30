using AutoMapper;
using GameStore.DAL;
using GameStore.DAL.Models;
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
            userManager = new UserManager<UserEntity>(new UserStore<UserEntity>(new GamesStoreContext()));
        }

        /// <summary>
        ///  Get by id
        /// </summary>
        public async Task<Model.Common.IUser> GetAsync(string username)
        {
            try
            {
                return Mapper.Map<Model.Common.IUser>(await repository.GetAsync<UserEntity>(c => c.UserName == username));
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
        public async Task<Model.Common.IUser> GetAsync(string username, string password)
        {
            try
            {
                UserEntity user;
                using (UserManager<UserEntity> userManager = manager())
                {
                    user = await userManager.FindAsync(username, password);
                }
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
                IdentityResult result = await userManager.CreateAsync(Mapper.Map<UserEntity>(user), user.PasswordHash);
                return result.Succeeded;
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }

        public Task<IUnitOfWork> CreateUnitOfWork()
        {
            try
            {
                return Task.FromResult<IUnitOfWork>(repository.CreateUnitOfWork());
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> UpdateAsync(Model.Common.IUser user, string password)
        {
            try
            {
                IdentityResult validation = await userManager.PasswordValidator.ValidateAsync(password);

                if (validation.Succeeded)
                {
                    user.PasswordHash = hasher.HashPassword(user.PasswordHash);

                    return await repository.UpdateAsync<UserEntity>(Mapper.Map<UserEntity>(user));
                }

                return 0;
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }

        /// <summary>
        /// Updates only user name and password proporites
        /// </summary>
        public async Task<int> UpdateEmailOrUsernameAsync(Model.Common.IUser user, string password)
        {
            try
            {
                IdentityResult validation = await userManager.PasswordValidator.ValidateAsync(password);

                if (validation.Succeeded)
                {
                    user.PasswordHash = hasher.HashPassword(user.PasswordHash);

                    // Only allows user name or email to change
                    return await repository.UpdateAsync<UserEntity>(Mapper.Map<UserEntity>(user), u => u.Email, u => u.UserName);
                }

                return 0;
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }

        }

        #region Private fields

        /// <summary>
        /// User manager initialize
        /// </summary>
        /// <returns>new user manager</returns>
        private UserManager<UserEntity> manager()
        {
            return new UserManager<UserEntity>(new UserStore<UserEntity>(new GamesStoreContext()));
        } 

        #endregion
    }
}
