using GameStore.Common;
using GameStore.Model.Common;
using GameStore.Repository.Common;
using Service.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Service
{
    public class PublisherService : IPublisherService
    {
        public IPublisherRepository PublisherRepository { get; private set; }
        public ISupportRepository SupportRepository { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="publisherRepository">Instance that inherits from ICompanyRepository</param>
        public PublisherService(IPublisherRepository publisherRepository, ISupportRepository supportRepository)
        {
            if (publisherRepository == null ||supportRepository == null)
                throw new ArgumentNullException();

            PublisherRepository = publisherRepository;
            SupportRepository = supportRepository;
        }

        /// <summary>
        /// Get by id
        /// </summary>
        public virtual Task<IPublisher> GetAsync(Guid id)
        {
            return PublisherRepository.GetAsync(id);
        }

        /// <summary>
        /// Get support info for publisher
        /// </summary>
        public virtual Task<ISupport> GetSupportAsync(Guid id)
        {
            return SupportRepository.GetAsync(id);
        }

        /// <summary>
        /// Get by name
        /// </summary>
        public virtual Task<IEnumerable<IPublisher>> GetRangeAsync(string name)
        {
            return PublisherRepository.GetRangeAsync(name);
        }

        /// <summary>
        /// Returns collection of publishers
        /// </summary>
        public virtual Task<IEnumerable<IPublisher>> GetRangeAsync(PublisherFilter filter = null)
        {
            return PublisherRepository.GetRangeAsync(filter);
        }
    }
}
