using GameStore.Repository.Common;
using GameStore.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Service
{
    /// <summary>
    /// Topic service
    /// </summary>
    public class TopicService : ITopicService
    {
        ITopicRepository repository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository">ITopicRepository object</param>
        public TopicService(ITopicRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Get topic
        /// </summary>
        /// <param name="id">Id to find by</param>
        /// <returns>Topic</returns>
        public async Task<Model.Common.ITopic> GetAsync(Guid id)
        {
            return await repository.GetAsync(id);
        }

        /// <summary>
        /// Get collection of topics
        /// </summary>
        /// <param name="filer">Filter options</param>
        /// <returns>Topic collection</returns>
        public async Task<ICollection<Model.Common.ITopic>> GetRangeAsync(GameStore.Common.GenericFilter filter)
        {
            return await repository.GetRangeAsync(filter);
        }

        /// <summary>
        /// Add topic async
        /// </summary>
        /// <param name="topic">Topic to add</param>
        /// <returns>The number of objects written to the underlying database.</returns>
        public async Task<int> AddAsync(Model.Common.ITopic topic)
        {
            return await repository.AddAsync(topic);
        }
    }
}
