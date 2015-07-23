using AutoMapper;
using GameStore.DAL.Models;
using GameStore.Model.Common;
using GameStore.Repository.Common;
using System;
using System.Threading.Tasks;

namespace GameStore.Repository
{
    public class InfoRepository : IInfoRepository
    {
        private readonly IRepository repository;

        public InfoRepository(IRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Get Iinfo entity
        /// </summary>
        public async Task<Model.Common.IInfo> GetAsync(Guid id)
        {
            try
            {
                return Mapper.Map<IInfo>(await repository.GetAsync<InfoEntity>(id));
            }
            catch (Exception ex)
            {              
                throw ex;
            }
        }

        /// <summary>
        /// Add async
        /// </summary>
        public async Task<int> AddAsync(Model.Common.IInfo info)
        {
            try
            {
                return await repository.AddAsync<InfoEntity>(Mapper.Map<InfoEntity>(info));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update IInfo entity
        /// </summary>
        public async Task<int> UpdateAsync(Model.Common.IInfo info)
        {
            try
            {
                return await repository.UpdateAsync<InfoEntity>(Mapper.Map<InfoEntity>(info));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Delete async
        /// </summary>
        public async Task<int> DeletAsync(Model.Common.IInfo info)
        {
            try
            {
                return await repository.DeleteAsync<InfoEntity>(Mapper.Map<InfoEntity>(info));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Delete 
        /// </summary>
        public async Task<int> DeleteAsync(Guid id)
        {
            try
            {
                return await this.DeletAsync(Mapper.Map<IInfo>(await repository.GetAsync<InfoEntity>(id)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
