using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GameStore.Repository.Common
{
    public interface IUnitOfWork : IDisposable
    {
        Task<T> AddAsync<T>(T entity) where T: class;
        Task<int> DeleteAsync<T>(T entity) where T:class;
        Task<T> UpdateAsync<T>(T entity) where T:class;
        Task<T> UpdateAsync<T>(T entity, params Expression<Func<T, object>>[] entityParameters) where T : class;
        Task<int> DeleteAsync<T>(Guid id) where T:class;
        Task<int> CommitAsync();
    }
}
