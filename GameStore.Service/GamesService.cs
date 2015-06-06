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
        public Task<Model.Common.IGame> GetAsync(int id)
        {
            return GamesRepository.GetAsync(id);
        }

        /// <summary>
        /// Gets game by name
        /// </summary>
        public Task<Model.Common.IGame> GetAsync(string name)
        {
            return GamesRepository.GetAsync(name);
        }

        /// <summary>
        /// Gets all games
        /// </summary>
        public Task<IEnumerable<Model.Common.IGame>> GetRangeAsync()
        {
            return GamesRepository.GetRangeAsync(); 
        }

        /// <summary>
        /// Get games that belong to publisher
        /// </summary>
        /// <param name="publisherId">FK id</param>
        /// <returns>Collection of games</returns>
        public Task<IEnumerable<Model.Common.IGame>> GetRangeAsync(int publisherId)
        {
            return GamesRepository.GetRangeAsync(publisherId);
        }
    }
}
