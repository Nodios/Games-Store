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
