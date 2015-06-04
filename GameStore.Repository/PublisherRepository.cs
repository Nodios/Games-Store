﻿using AutoMapper;
using GameStore.DAL.Models;
using GameStore.Model.Common;
using GameStore.Repository.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Repository
{
    public class PublisherRepository : IPublisherRepository
    {
        private IRepository repository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository">Irepository</param>
        public PublisherRepository(IRepository repository)
        {
            this.repository = repository;
        }

        #region Public methos

        /// <summary>
        /// Get company by id
        /// </summary>
        public async Task<Model.Common.IPublisher> GetAsync(int id)
        {
            try
            {
                return Mapper.Map<IPublisher>(await repository.GetAsync<PublisherEntity>(id));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Get by name
        /// </summary>
        public async Task<Model.Common.IPublisher> GetAsync(string name)
        {
            try
            {
                return Mapper.Map<IPublisher>(await 
                    repository.GetAsync<PublisherEntity>(c => c.Name == name));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Get all
        /// </summary>
        public async Task<IEnumerable<Model.Common.IPublisher>> GetRangeAsync()
        {
            try
            {
                return Mapper.Map<IEnumerable<IPublisher>>(await repository.GetRangeAsync<PublisherEntity>());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Adds ICompany entity
        /// </summary>
        public async Task<int> AddAsync(Model.Common.IPublisher company)
        {
            try
            {
                return await repository.AddAsync<PublisherEntity>(Mapper.Map<PublisherEntity>(company));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Updates
        /// </summary>
        public async Task<int> UpdateAsync(Model.Common.IPublisher company)
        {
            try
            {
                return await repository.UpdateAsync<PublisherEntity>(Mapper.Map<PublisherEntity>(company));
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
                return await this.DeleteAsync(Mapper.Map<IPublisher>
                    (await repository.GetAsync<PublisherEntity>(id)));
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Delete entity
        /// </summary>
        public async Task<int> DeleteAsync(Model.Common.IPublisher company)
        {
            try
            {
                return await repository.DeleteAsync<PublisherEntity>(Mapper.Map<PublisherEntity>(company));
            }
            catch(Exception ex)
            {
                throw ex; 
            }
        }  

        #endregion
    }
}
