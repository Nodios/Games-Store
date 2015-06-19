using GameStore.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GameStore.Repository.Common
{
    public interface IUserRepository
    {
        Task<IUser> GetAsync(Guid id);
        Task<IEnumerable<IUser>> GetAsync(Expression<Func<IUser, bool>> match);
        Task<int> AddAsync(IUser user);
        Task<int> UpdateAsync(IUser user);
        Task<int> DeleteAsync(IUser user);
        Task<int> DeleteAsync(Guid id);
    }
}
