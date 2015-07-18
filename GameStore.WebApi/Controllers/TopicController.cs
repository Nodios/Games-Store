using AutoMapper;
using GameStore.Common;
using GameStore.Model.Common;
using GameStore.Service.Common;
using GameStore.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace GameStore.WebApi.Controllers
{
    [RoutePrefix("api/topic")]
    public class TopicController : ApiController
    {
        private ITopicService service;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="service">ITopicService</param>
        public TopicController(ITopicService service)
        {
            this.service = service;
        }

        #region Get 

        /// <summary>
        /// Get by id
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>Resposne with topic</returns>
        [Route("getById/{id}")]
        [HttpGet]
        public async Task<HttpResponseMessage> Get(Guid id)
        {
            try
            {
                TopicModel result = Mapper.Map<TopicModel>(await service.GetAsync(id));

                if (result == null)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Error while getting topic.");

                return Request.CreateResponse(HttpStatusCode.OK, result);

            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        /// <summary>
        /// Get topics
        /// </summary>
        /// <param name="pageNumber">Pagenumber</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>Collection of topics</returns>
        [Route("{pageNumber}/{pageSize}")]
        [HttpGet]
        public async Task<HttpResponseMessage> Get(int pageNumber, int pageSize)
        {
            try
            {
                if (pageNumber < 1 || pageSize < 1)
                {
                    pageSize = 1;
                    pageNumber = 1;
                }

                GenericFilter filter = new GenericFilter(pageNumber, pageSize);

                ICollection<TopicModel> result = Mapper.Map<ICollection<TopicModel>>(await service.GetRangeAsync(filter));

                return Request.CreateResponse(HttpStatusCode.OK, result);

            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("GetByName/{search}/{pageNumber}/{pageSize}")]
        [HttpGet]
        public async Task<HttpResponseMessage> Get(string search, int pageNumber, int pageSize)
        {
            try
            {
                if (pageNumber < 1 || pageSize < 1)
                {
                    pageSize = 1;
                    pageNumber = 1;
                }

                GenericFilter filter = new GenericFilter(pageNumber, pageSize);

                ICollection<TopicModel> result = Mapper.Map<ICollection<TopicModel>>(await service.GetRangeAsync(filter, search));

                return Request.CreateResponse(HttpStatusCode.OK, result);

            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        } 

        #endregion

        /// <summary>
        /// Insert new topic
        /// </summary>
        /// <param name="topic">Topic model</param>
        /// <returns>The number of objects written to the underlying database if OK.</returns>
        [Authorize]
        [HttpPost]
        public async Task<HttpResponseMessage> Insert(TopicModel topic)
        {
            try
            {
                int result = await service.AddAsync(Mapper.Map<ITopic>(topic));

                if (result == 0)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Add operation error.");

                return Request.CreateResponse(HttpStatusCode.OK, result);

            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
