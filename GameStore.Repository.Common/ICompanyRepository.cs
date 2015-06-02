using GameStore.Model.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Repository.Common
{
    public interface ICompanyRepository
    {
        Task<ICompany> GetAsync(int id);
        Task<ICompany> GetAsync(string name);
        Task<IEnumerable<ICompany>> GetRangeAsync();

        Task<int> AddAsync(ICompany company);
        Task<int> UpdateAsync(ICompany company);
        Task<int> DeleteAsync(int id);
        Task<int> DeleteAsync(ICompany company);

    }
}
