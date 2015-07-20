using System.Threading.Tasks;

namespace GameStore.WindowsApp.Model
{
    public interface IDataService
    {
        Task<DataItem> GetData();
    }
}