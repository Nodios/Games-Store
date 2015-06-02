using AutoMapper;
using GameStore.DAL.Models;
using GameStore.Model.Common;
using GameStore.Repository.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private IRepository repository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository">Irepository</param>
        public CompanyRepository(IRepository repository)
        {
            this.repository = repository;
        }

        #region Public methos

        /// <summary>
        /// Get company by id
        /// </summary>
        public async Task<Model.Common.ICompany> GetAsync(int id)
        {
            try
            {
                return Mapper.Map<ICompany>(await repository.GetAsync<CompanyEntity>(id));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Get by name
        /// </summary>
        public async Task<Model.Common.ICompany> GetAsync(string name)
        {
            try
            {
                return Mapper.Map<ICompany>(await repository.GetAsync<CompanyEntity>(c => c.Name.ToLower() == name.ToLower()));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Get all
        /// </summary>
        public async Task<IEnumerable<Model.Common.ICompany>> GetRangeAsync()
        {
            try
            {
                return Mapper.Map<IEnumerable<ICompany>>(await repository.GetRangeAsync<CompanyEntity>());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Adds ICompany entity
        /// </summary>
        public async Task<int> AddAsync(Model.Common.ICompany company)
        {
            try
            {
                return await repository.AddAsync<CompanyEntity>(Mapper.Map<CompanyEntity>(company));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Updates
        /// </summary>
        public async Task<int> UpdateAsync(Model.Common.ICompany company)
        {
            try
            {
                return await repository.UpdateAsync<CompanyEntity>(Mapper.Map<CompanyEntity>(company));
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Delete with id
        /// </summary>
        public async Task<int> DeleteAsync(int id)
        {
            try
            {
                return await this.DeleteAsync(Mapper.Map<ICompany>
                    (await repository.GetAsync<CompanyEntity>(id)));
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Delete entity
        /// </summary>
        public async Task<int> DeleteAsync(Model.Common.ICompany company)
        {
            try
            {
                return await repository.DeleteAsync<CompanyEntity>(Mapper.Map<CompanyEntity>(company));
            }
            catch(Exception ex)
            {
                throw ex; 
            }
        }  

        #endregion
    }
}
