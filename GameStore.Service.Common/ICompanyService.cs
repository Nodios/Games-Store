using GameStore.Model.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Common
{
    public interface ICompanyService
    {
        Task<ICompany> GetAsync(int id);
        Task<IEnumerable<ICompany>> GetRangeAsync();

    }
}
