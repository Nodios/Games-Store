using GameStore.Model.Common;
using GameStore.Repository.Common;
using GameStore.Service.Common;
using System;
using System.Threading.Tasks;

namespace GameStore.Service
{
    public class UserService : IUserService
    {
        public IUserRepository UserRepository { get; private set; }

        public UserService(IUserRepository userRepo)
        {
            UserRepository = userRepo;
        }

        /// <summary>
        /// Find user by username
        /// </summary>
        public async Task<IUser> FindAsync(string username)
        {
            try
            {
                return await UserRepository.GetAsync(username);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        /// <summary>
        /// Find user and validate him
        /// </summary>
        /// <param name="username">Username to search by</param>
        /// <param name="password">Password for user validation</param>
        /// <returns>User</returns>
        public async Task<IUser> FindAsync(string username, string password)
        {
            try
            {
                return await UserRepository.GetAsync(username, password);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        /// <summary>
        /// Register add user
        /// </summary>
        public async Task<bool> RegisterUser(IUser user, string password)
        {
            try
            {
                return await UserRepository.RegisterUser(user, password);      
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Updates username or password
        /// </summary>
        /// <param name="user">New user data</param>
        /// <param name="password">Validation password</param>
        /// <returns>Updated user</returns>
        public async Task<IUser> UpdateEmailOrUsernameAsync(IUser user, string password)
        {
            return await UserRepository.UpdateUserEmailOrUsernameAsync(user, password);
        }

        /// <summary>
        /// Changes user password
        /// </summary>
        /// <param name="userId">User id</param>
        /// <param name="oldPassword">Old password, for confirmation</param>
        /// <param name="newPassword">New password</param>
        /// <returns>True if success, false otherwise</returns>
        public async Task<bool> UpdatePasswordAsync(string userId, string oldPassword, string newPassword)
        {
            return await UserRepository.UpdateUserPasswordAsync(userId, oldPassword, newPassword);
        }
    }
}
