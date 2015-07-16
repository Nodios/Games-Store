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
    public class GameRepository : IGameRepository
    {
        private IRepository repository;

        public GameRepository(IRepository repository)
        {
            this.repository = repository;
        }

        #region Get

        /// <summary>
        /// Get by id
        /// </summary>
        public async Task<Model.Common.IGame> GetAsync(Guid id)
        {
            try
            {
                return Mapper.Map<IGame>(await repository.GetAsync<GameEntity>(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get by name, where games are not in cart
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<IEnumerable<IGame>> GetRangeAsync(string name, GenericFilter filter)
        {
            try
            {
                return Mapper.Map<IEnumerable<IGame>>(await repository.Where<GameEntity>()
                    .Where(g => g.IsInCart == false && g.Name.Contains(name))
                    .OrderBy(g => g.Name)
                    .Skip((filter.PageNumber * filter.PageSize) - filter.PageSize)
                    .Take(filter.PageSize).ToListAsync());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get all where games are not in cart
        /// </summary>
        public async Task<IEnumerable<Model.Common.IGame>> GetRangeAsync(GenericFilter filter = null)
        {
            try
            {
                if (filter == null)
                    filter = new GenericFilter(1, 5);

                return Mapper.Map<IEnumerable<IGame>>(await
                    repository.Where<GameEntity>().Where(g => g.IsInCart == false)
                    .OrderBy(g => g.Name)
                    .Skip((filter.PageNumber * filter.PageSize) - filter.PageSize)
                    .Take(filter.PageSize).ToListAsync());

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
        public async Task<IEnumerable<IGame>> GetRangeAsync(Guid publisherId, GenericFilter filter = null)
        {
            try
            {
                if (filter != null)
                {
                    return Mapper.Map<IEnumerable<IGame>>(await repository
                        .Where<GameEntity>().Where(g => g.PublisherId == publisherId && g.IsInCart == false)
                        .OrderBy(g => g.Name)
                        .Skip((filter.PageNumber * filter.PageSize) - filter.PageSize)
                        .Take(filter.PageSize).ToListAsync());
                }
                else
                {
                    return Mapper.Map<IEnumerable<IGame>>(await repository
                        .GetRangeAsync<GameEntity>(g => g.PublisherId == publisherId && g.IsInCart == false));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Update

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

        #endregion

        #region Add

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

        #endregion

        #region Delete

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
        public async Task<int> DeleteAsync(Guid id)
        {
            try
            {
                return await repository.DeleteAsync<GameEntity>(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Delete async
        /// </summary>
        /// <param name="id">Id params</param>
        public async Task<int> DeleteAsync(params Guid[] id)
        {
            try
            {
                IUnitOfWork uow = repository.CreateUnitOfWork();

                foreach (Guid i in id)
                {
                    await uow.DeleteAsync<GameEntity>(i);
                }

                return await uow.CommitAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

    }
}
