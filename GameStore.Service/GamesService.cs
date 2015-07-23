using GameStore.Common;
using GameStore.Model.Common;
using GameStore.Repository.Common;
using GameStore.Service.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Service
{
    public class GamesService : IGamesService
    {
        private readonly IGameRepository gamesRepository;

        public GamesService(IGameRepository repository)
        {
            gamesRepository = repository;
            if (gamesRepository == null)
                throw new ArgumentNullException("Argument cannot be null and should be of type IGamesRepository");


        }

        /// <summary>
        /// Gets game by id
        /// </summary>
        public Task<Model.Common.IGame> GetAsync(Guid id)
        {
            return gamesRepository.GetAsync(id);
        }

        /// <summary>
        /// Gets game by name
        /// </summary>
        public Task<IEnumerable<IGame>> GetRangeAsync(string name, GenericFilter filter)
        {
            return gamesRepository.GetRangeAsync(name, filter);
        }

        /// <summary>
        /// Gets all games
        /// </summary>
        public Task<IEnumerable<Model.Common.IGame>> GetRangeAsync(GenericFilter filter = null)
        {
            return gamesRepository.GetRangeAsync(filter); 
        }

        /// <summary>
        /// Get games that belong to publisher
        /// </summary>
        /// <param name="publisherId">FK id</param>
        /// <returns>Collection of games</returns>
        public Task<IEnumerable<Model.Common.IGame>> GetRangeAsync(Guid publisherId, GenericFilter filter = null)
        {
            return gamesRepository.GetRangeAsync(publisherId, filter);
        }

        /// <summary>
        /// Delete single game
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>1 if success, 0 otherwise</returns>
        public Task<int> DeleteAsync(Guid id)
        {
            return gamesRepository.DeleteAsync(id);
        }

        /// <summary>
        /// Delete collection of games
        /// </summary>
        /// <param name="id">Id's for all games to delete</param>
        /// <returns>1 if success, 0 otherwise</returns>
        public Task<int> DeleteAsync(params Guid[] id)
        {
            return gamesRepository.DeleteAsync(id);
        }
    }
}
