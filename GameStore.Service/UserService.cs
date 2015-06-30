using GameStore.Model.Common;
using GameStore.Repository.Common;
using GameStore.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public async Task<bool> RegisterUser(Model.Common.IUser user)
        {
            try
            {
                return await UserRepository.RegisterUser(user);      
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<int> UpdateEmailOrUsernameAsync(Model.Common.IUser user, string password)
        {
            return await UserRepository.UpdateEmailOrUsernameAsync(user, password);
        }
    }
}
