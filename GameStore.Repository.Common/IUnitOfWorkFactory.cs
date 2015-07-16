
using Microsoft.AspNet.Identity;
namespace GameStore.Repository.Common
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork CreateUnitOfWork();
    }
}
