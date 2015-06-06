using AutoMapper;
using GameStore.DAL.Models;
using GameStore.Model.Common;
using GameStore.Repository.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Repository
{
    public class GameRepository : IGameRepository
    {
        private IRepository repository;

        public GameRepository(IRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Get by id
        /// </summary>
        public async Task<Model.Common.IGame> GetAsync(int id)
        {
            try
            {
                return Mapper.Map<IGame>(await repository.GetAsync<GameEntity>(id));
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<IGame> GetAsync(string name)
        {
            try
            {
                return Mapper.Map<IGame>(await repository.GetAsync<GameEntity>(c => c.Name == name));
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get all
        /// </summary>
        public async Task<IEnumerable<Model.Common.IGame>> GetRangeAsync()
        {
            try
            {
                return Mapper.Map<IEnumerable<IGame>>(await repository.GetRangeAsync<GameEntity>());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Get games from publisher
        /// </summary>
        /// <param name="publisherId">FK</param>
        /// <returns>Collection of games that belong to publisher</returns>
        public async Task<IEnumerable<IGame>> GetRangeAsync(int publisherId)
        {
            try
            {
                return Mapper.Map<IEnumerable<IGame>>(await repository
                    .GetRangeAsync<GameEntity>(g => g.PublisherId == publisherId));
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update game
        /// </summary>
        public async Task<int> UpdateAsync(Model.Common.IGame game)
        {
            try
            {
                return await repository.UpdateAsync<GameEntity>(Mapper.Map<GameEntity>(game));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Add game
        /// </summary>
        public async Task<int> AddAsync(Model.Common.IGame game)
        {
            try
            {
                return await repository.AddAsync<GameEntity>(Mapper.Map<GameEntity>(game));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Delete game
        /// </summary>
        public async Task<int> DeleteAsync(Model.Common.IGame game)
        {
            try
            {
                return await repository.DeleteAsync<GameEntity>(Mapper.Map<GameEntity>(game));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Delete game
        /// </summary>
        public async Task<int> DeleteAsync(int id)
        {
            try
            {
                return await this.DeleteAsync(Mapper.Map<IGame>(await repository.GetAsync<GameEntity>(id)));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
