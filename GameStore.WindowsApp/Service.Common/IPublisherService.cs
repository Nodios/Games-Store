using GameStore.WindowsApp.Model;
using GameStore.WindowsApp.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.WindowsApp.Service.Common
{
    public interface IPublisherService
    {
        Task<IEnumerable<Publisher>> GetRangeAsync(string name, GenericFilter filter);
        Task<Support> GetSupportAsync(Guid id);
        Task<IEnumerable<Publisher>> GetRangeAsync(GenericFilter filter);
    }
}
