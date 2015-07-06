using GameStore.Model.Common;
using GameStore.Repository.Common;
using GameStore.Service.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Service
{
    public class GameImageService : IGameImageService
    {
        IGameImageRepository repository;

        public GameImageService(IGameImageRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<IGameImage>> GetRangeAsync(Guid gameId)
        {
            return await repository.GetRangeAsync(gameId);
        }
    }
}
