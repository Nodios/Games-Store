using GameStore.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GameStore.Repository.Common
{
    public interface IUserRepository
    {
        Task<IUser> GetAsync(string username);

        Task<IEnumerable<IUser>> GetAsync(Expression<Func<IUser, bool>> match);
        Task<int> AddAsync(IUser user);
        Task<bool> UpdateAsync(IUser user, string password);
        Task<int> DeleteAsync(IUser user);
        Task<int> DeleteAsync(Guid id);
        Task<bool> RegisterUser(IUser user);
        Task<IUser> GetAsync(string username, string password);
        Task<IUnitOfWork> CreateUnitOfWork();
    }
}
