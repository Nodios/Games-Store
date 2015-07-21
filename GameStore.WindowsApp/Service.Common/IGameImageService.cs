using GameStore.WindowsApp.Model;
using System;
using System.Threading.Tasks;

namespace GameStore.WindowsApp.Service.Common
{
    /// <summary>
    /// Provides method signature for game image
    /// </summary>
    public interface IGameImageService
    {
        Task<GameImage> GetAsync(Guid gameId);
    }
}
