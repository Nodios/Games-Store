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

        /// <summary>
        /// Constructor
        /// </summary>
        public UserRepository(IRepository repository)
        {
            this.repository = repository;
            hasher = new PasswordHasher();
        }

        #region Other methods

        /// <summary>
        /// Initalize user manager
        /// </summary>
        /// <returns>new user manager</returns>
        private UserManager<UserEntity> createUserManager()
        {
            return new UserManager<UserEntity>(new UserStore<UserEntity>(new GamesStoreContext()));
        }

        #endregion

        #region Get 

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
                using (UserManager<UserEntity> userManager = createUserManager())
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

        #endregion

        #region Add

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
        /// Registers adds user
        /// </summary>
        /// <param name="user"></param>
        /// <returns>True if success, false otherwise</returns>
        public async Task<bool> RegisterUser(Model.Common.IUser user, string password)
        {
            try
            {
                using (UserManager<UserEntity> userManager = createUserManager())
                {
                    IdentityResult result = await userManager.CreateAsync(Mapper.Map<UserEntity>(user), password);
                    return result.Succeeded;
                }
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        } 
	#endregion

        #region Delete

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

	    #endregion

        #region  Update

	    /// <summary>
        /// Updates user, return int as result
        /// </summary>
        /// <param name="user">User</param>
        /// <param name="password">User password for validation</param>
        /// <returns>Int { 0: operation failed }</returns>
        public async Task<int> UpdateAsync(Model.Common.IUser user)
        {
            try
            {
                return await repository.UpdateAsync<UserEntity>(Mapper.Map<UserEntity>(user));
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }

        /// <summary>
        /// Updates user and return updated user
        /// </summary>
        /// <param name="user">User to update</param>
        /// <param name="password">User password</param>
        /// <returns>IUser</returns>
        public async Task<Model.Common.IUser> UpdateUserAsync(Model.Common.IUser user, string password)
        {
            try
            {
                IUnitOfWork uow = repository.CreateUnitOfWork();
                bool passwordValid = false;
                Task<UserEntity> result = null;
           
                // Check if user is valid
                using (UserManager<UserEntity> UserManager = createUserManager())
                {
                    UserEntity userToCheck = await UserManager.FindByIdAsync(user.Id);
                    passwordValid = await UserManager.CheckPasswordAsync(userToCheck, password);
                }

                if (passwordValid)
                    result = uow.UpdateWithAddAsync<UserEntity>(Mapper.Map<UserEntity>(user));
                else
                    throw new Exception("Invalid password");

                await uow.CommitAsync();
                return await Task.FromResult(Mapper.Map<Model.Common.IUser>(result.Result) as Model.Common.IUser);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Updates only username or email
        /// </summary>
        /// <param name="user">UserToUpdate</param>
        /// <param name="password">User password</param>
        /// <returns>IUser</returns>
        public async Task<Model.Common.IUser> UpdateUserEmailOrUsernameAsync(Model.Common.IUser user,string password)
        {
            try
            {
                IUnitOfWork uow = repository.CreateUnitOfWork();
                bool passwordValid = false;
                Task<UserEntity> result = null;

                // Check if user is valid
                using (UserManager<UserEntity> UserManager = createUserManager())
                {
                    UserEntity userToCheck = await UserManager.FindByIdAsync(user.Id);
                    passwordValid = await UserManager.CheckPasswordAsync(userToCheck, password);
                }

                if (passwordValid)
                    result = uow.UpdateWithAddAsync<UserEntity>(Mapper.Map<UserEntity>(user), u => u.Email, u => u.UserName);
                else
                    throw new Exception("Invalid password.");

                await uow.CommitAsync();
                return await Task.FromResult(Mapper.Map<Model.Common.IUser>(result.Result) as Model.Common.IUser);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Change user password
        /// </summary>
        /// <param name="user">User </param>
        /// <param name="newPassword">New password</param>
        /// <returns>IUser</returns>
        public async Task<bool> UpdateUserPasswordAsync(string userId,string oldPassword, string newPassword)
        {
            try
            {

                IdentityResult result;
                using (UserManager<UserEntity> UserManager = createUserManager())
                {
                    result = await UserManager.ChangePasswordAsync(userId, oldPassword, newPassword);              
                }

                return result.Succeeded;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

	    #endregion


   
    }
}
