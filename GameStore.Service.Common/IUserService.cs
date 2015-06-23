using GameStore.Model.Common;
using System.Threading.Tasks;

namespace GameStore.Service.Common
{
    public interface IUserService
    {
        Task<bool> RegisterUser(IUser user);
        Task<IUser> FindAsync(string username, string password);
    }
}
