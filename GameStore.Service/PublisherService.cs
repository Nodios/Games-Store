using GameStore.Common;
using GameStore.Model.Common;
using GameStore.Repository.Common;
using GameStore.Service.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Service
{
    public class PublisherService : IPublisherService
    {
        private readonly IPublisherRepository publisherRepository;
        private readonly ISupportRepository supportRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="publisherRepository">Instance that inherits from ICompanyRepository</param>
        public PublisherService(IPublisherRepository publisherRepository, ISupportRepository supportRepository)
        {
            if (publisherRepository == null ||supportRepository == null)
                throw new ArgumentNullException();

            this.publisherRepository = publisherRepository;
            this.supportRepository = supportRepository;
        }

        /// <summary>
        /// Get by id
        /// </summary>
        public virtual Task<IPublisher> GetAsync(Guid id)
        {
            return publisherRepository.GetAsync(id);
        }

        /// <summary>
        /// Get support info for publisher
        /// </summary>
        public virtual Task<ISupport> GetSupportAsync(Guid id)
        {
            return supportRepository.GetAsync(id);
        }

        /// <summary>
        /// Get by name
        /// </summary>
        public virtual Task<IEnumerable<IPublisher>> GetRangeAsync(string name, GenericFilter filter)
        {
            return publisherRepository.GetRangeAsync(name, filter);
        }

        /// <summary>
        /// Returns collection of publishers
        /// </summary>
        public virtual Task<IEnumerable<IPublisher>> GetRangeAsync(GenericFilter filter = null)
        {
            return publisherRepository.GetRangeAsync(filter);
        }
    }
}
