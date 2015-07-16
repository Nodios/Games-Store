using AutoMapper;
using GameStore.Common;
using GameStore.DAL.Models;
using GameStore.Model.Common;
using GameStore.Repository.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Repository
{
    public class GameImageRepository : IGameImageRepository
    {
        IRepository repository;

        public GameImageRepository(IRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Get game image by id
        /// </summary>
        public async Task<Model.Common.IGameImage> GetAsync(Guid id)
        {
            try
            {
                return await repository.GetAsync<IGameImage>(id);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        /// <summary>
        /// Get collection of game images
        /// </summary>
        /// <param name="filter">Filter, which provides options for pagination</param>
        /// <returns>GameImages collection</returns>
        public async Task<IEnumerable<Model.Common.IGameImage>> GetRangeAsync(GenericFilter filter)
        {
            try
            {
                return Mapper.Map<IEnumerable<IGameImage>>(await repository.Where<GameImageEntity>()
                    .OrderBy(g => g.Id)
                    .Skip((filter.PageNumber * filter.PageSize) - filter.PageSize)
                    .Take(filter.PageSize).ToListAsync());
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        /// <summary>
        /// Get collection by fk
        /// </summary>
        /// <param name="gameId">Foreign key</param>
        /// <param name="filter">Filtering options</param>
        /// <returns>ICollection of IGameImage</returns>
        public async Task<IEnumerable<IGameImage>> GetRangeAsync(Guid gameId, GenericFilter filter)
        {
            try
            {
                return Mapper.Map<IEnumerable<IGameImage>>(await repository.Where<GameImageEntity>()
                    .Where(g => g.GameId == gameId)
                   .OrderBy(g => g.Id)
                   .Skip((filter.PageNumber * filter.PageSize) - filter.PageSize)
                   .Take(filter.PageSize).ToListAsync());
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        /// <summary>
        /// Add new game image to database
        /// </summary>
        /// <param name="gameImate">IGameImage to add</param>
        /// <returns>1 is success, 0 otherwise</returns>
        public async Task<int> AddAsync(Model.Common.IGameImage gameImate)
        {
            try
            {
                return await repository.AddAsync<GameImageEntity>(AutoMapper.Mapper.Map<GameImageEntity>(gameImate));
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        /// <summary>
        /// Update existing game image
        /// </summary>
        /// <param name="gameImage">Game image to update</param>
        /// <returns>1 if success , 0 otherwise</returns>
        public async Task<int> UpdateAsync(Model.Common.IGameImage gameImage)
        {
            try
            {
                return await repository.UpdateAsync<GameImageEntity>(AutoMapper.Mapper.Map<GameImageEntity>(gameImage));
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        /// <summary>
        /// Delete game image
        /// </summary>
        /// <param name="gameImage">Game image to delete</param>
        /// <returns>1 if success , 0 otherwise</returns>
        public async Task<int> DeleteAsync(Model.Common.IGameImage gameImage)
        {
            try
            {
                return await repository.DeleteAsync<GameImageEntity>(AutoMapper.Mapper.Map<GameImageEntity>(gameImage));
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
