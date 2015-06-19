using GameStore.Common;
using GameStore.Model.Common;
using GameStore.Repository.Common;
using Service.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Service
{
    public class GamesService : IGamesService
    {
        /// <summary>
        /// Get games repository
        /// </summary>
        public IGameRepository GamesRepository { get; private set; }

        public GamesService(IGameRepository repository)
        {
            GamesRepository = repository;
            if (GamesRepository == null)
                throw new ArgumentNullException("Argument cannot be null and should be of type IGamesRepository");


        }

        /// <summary>
        /// Gets game by id
        /// </summary>
        public Task<Model.Common.IGame> GetAsync(Guid id)
        {
            return GamesRepository.GetAsync(id);
        }

        /// <summary>
        /// Gets game by name
        /// </summary>
        public Task<IEnumerable<IGame>> GetRangeAsync(string name)
        {
            return GamesRepository.GetRangeAsync(name);
        }

        /// <summary>
        /// Gets all games
        /// </summary>
        public Task<IEnumerable<Model.Common.IGame>> GetRangeAsync(GameFilter filter = null)
        {
            return GamesRepository.GetRangeAsync(filter); 
        }

        /// <summary>
        /// Get games that belong to publisher
        /// </summary>
        /// <param name="publisherId">FK id</param>
        /// <returns>Collection of games</returns>
        public Task<IEnumerable<Model.Common.IGame>> GetRangeAsync(Guid publisherId)
        {
            return GamesRepository.GetRangeAsync(publisherId);
        }
    }
}
