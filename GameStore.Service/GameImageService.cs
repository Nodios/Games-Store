﻿using GameStore.Common;
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
        private readonly IGameImageRepository repository;

        public GameImageService(IGameImageRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Get images that belong to game
        /// </summary>
        /// <param name="gameId">GameId</param>
        /// <param name="filter">Filter</param>
        /// <returns>Collection of games</returns>
        public async Task<IEnumerable<IGameImage>> GetRangeAsync(Guid gameId, GenericFilter filter)
        {
            return await repository.GetRangeAsync(gameId, filter);
        }
    }
}
