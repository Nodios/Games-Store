﻿using GameStore.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GameStore.Repository.Common
{
    public interface IUserRepository
    {
        // Get
        Task<IUser> GetAsync(string username);
        Task<IEnumerable<IUser>> GetAsync(Expression<Func<IUser, bool>> match);
        Task<IUser> GetAsync(string username, string password);

        // Add
        Task<int> AddAsync(IUser user);
        Task<bool> RegisterUser(IUser user, string password);

        // Update
        Task<int> UpdateAsync(IUser user);
        Task<IUser> UpdateUserAsync(IUser user, string password);
        Task<IUser> UpdateUserEmailOrUsernameAsync(IUser user, string password);
        Task<IUser> UpdateUserPasswordAsync(IUser user, string newPassword);

        // Delete
        Task<int> DeleteAsync(IUser user);
        Task<int> DeleteAsync(Guid id);

        Task<IUnitOfWork> CreateUnitOfWork();
    }
}
