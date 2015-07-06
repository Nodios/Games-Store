using AutoMapper;
using GameStore.DAL.Models;
using GameStore.Model.Common;
using GameStore.Repository.Common;
using System;
using System.Collections.Generic;
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

        public async Task<IEnumerable<Model.Common.IGameImage>> GetRangeAsync()
        {
            try
            {
                return await repository.GetRangeAsync<IGameImage>();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public async Task<IEnumerable<IGameImage>> GetRangeAsync(Guid gameId)
        {
            try
            {
                return Mapper.Map<IEnumerable<IGameImage>>(await repository.GetRangeAsync<GameImageEntity>(g => g.GameId == gameId));
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
