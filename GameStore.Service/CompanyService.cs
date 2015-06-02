using GameStore.Model.Common;
using GameStore.Repository.Common;
using Service.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Service
{
    public class CompanyService : ICompanyService
    {
        public ICompanyRepository Repository { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository">Instance that inherits from ICompanyRepository</param>
        public CompanyService(ICompanyRepository repository)
        {
            if (repository == null)
                throw new ArgumentNullException();

            Repository = repository;
        }

        /// <summary>
        /// Get by id
        /// </summary>
        public virtual Task<ICompany> GetAsync(int id)
        {
            return Repository.GetAsync(id);
        }

        /// <summary>
        /// Returns collection of publishers
        /// </summary>
        public virtual Task<IEnumerable<ICompany>> GetRangeAsync()
        {
            return Repository.GetRangeAsync();
        }
    }
}
