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
        public async Task<bool> RegisterUser(Model.Common.IUser user, string password)
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

        public async Task<Model.Common.IUser> UpdateEmailOrUsernameAsync(Model.Common.IUser user, string password)
        {
            return await UserRepository.UpdateUserEmailOrUsernameAsync(user, password);
        }
    }
}
