using AutoMapper;
using GameStore.DAL.Models;
using GameStore.Model.Common;
using GameStore.Repository.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Repository
{
    public class SupportRepository : ISupportRepository
    {
        private readonly IRepository repository;

        public SupportRepository(IRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Get by id
        /// </summary>
        public async Task<Model.Common.ISupport> GetAsync(Guid id)
        {
            try
            {
                return Mapper.Map<ISupport>(await repository.GetAsync<SupportEntity>(id));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Get all async
        /// </summary>
        public async Task<IEnumerable<ISupport>> GetAsync()
        {
            try
            {
                return Mapper.Map<IEnumerable<ISupport>>(
                    await repository.GetRangeAsync<SupportEntity>());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Add entity
        /// </summary>>
        public async Task<int> AddAsync(Model.Common.ISupport support)
        {
            try
            {
                return await repository.AddAsync<SupportEntity>(Mapper.Map<SupportEntity>(support));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Update entity
        /// </summary>
        public async Task<int> UpdateAsync(Model.Common.ISupport support)
        {
            try
            {
                return await repository.UpdateAsync<SupportEntity>
                    (Mapper.Map<SupportEntity>(support));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Delete with id
        /// </summary>
        public async Task<int> DeleteAsync(Guid id)
        {
            try
            {
                return await this.DeleteAsync(Mapper.Map<ISupport>(await
                    repository.GetAsync<SupportEntity>(id)));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Delete entity
        /// </summary>
        public async Task<int> DeleteAsync(Model.Common.ISupport support)
        {
            try
            {
                return await repository.DeleteAsync<SupportEntity>
                    (Mapper.Map<SupportEntity>(support));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
