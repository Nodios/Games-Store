using GameStore.Model.Common;
using System.Threading.Tasks;

namespace GameStore.Service.Common
{
    public interface IUserService
    {
        Task<IUser> FindAsync(string username);
        Task<IUser> FindAsync(string username, string password);
        Task<bool> RegisterUser(IUser user);
        Task<int> UpdateEmailOrUsernameAsync(Model.Common.IUser user, string password);
    }
}
