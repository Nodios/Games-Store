using GameStore.WindowsApp.Model;
using System.Threading.Tasks;

namespace GameStore.WindowsApp.Service.Common
{
    public interface IUserService 
    {
        Task<User> GetAsync(string username);
        Task<User> FindAsync(string username, string password);
        Task<bool> RegisterUser(User user, string password);
        Task<User> UpdateEmailOrUsernameAsync(User user, string password);
        Task<bool> UpdatePasswordAsync(string userId, string oldPassword, string newPassword);
    }
}
