using AutoMapper;
using GameStore.Model;
using GameStore.Model.Common;
using Service.Common;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace GameStore.WebApi.Controllers
{
    [RoutePrefix("api/Publisher")]
    public class PublisherController : ApiController
    {
        private IPublisherService PublisherService;

        public PublisherController(IPublisherService service)
        {
            PublisherService = service;    
        }

        // GET: api/Publisher
        public async Task<HttpResponseMessage> Get()
        {
            try
            {
                IEnumerable<IPublisher> result = await PublisherService.GetRangeAsync();
                if (result != null)
                    return Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<IEnumerable<PublisherModel>>(result));
                else
                    return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // GET: api/Publisher/5
        public async Task<HttpResponseMessage> Get(int id)
        {
            try
            {
                IPublisher result = await PublisherService.GetAsync(id);

                if (result != null)
                    return Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<PublisherModel>(result));
                else
                    return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        //Get: api/Publisher/GetByName/0/Ea
        [HttpGet()]
        public async Task<HttpResponseMessage> GetByName(string name)
        {
            try
            {
                IPublisher result = await PublisherService.GetAsync(name);

                if (result != null)
                    return Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<PublisherModel>(result));
                else
                    return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadGateway, ex.Message);
            }
        }

        [HttpGet()]
        //Get: api/Publisher/GetSupport/0
        public async Task<HttpResponseMessage> GetSupport(int id)
        {
            try
            {
                ISupport result = await PublisherService.GetSupportAsync(id);

                if (result != null)
                    return Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<SupportModel>(result));
                else
                    return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        /// <summary>
        /// Publisher class
        /// </summary>
        public class PublisherModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
        }

        /// <summary>
        /// Support class
        /// </summary>
        public class SupportModel
        {
            public int PublisherId { get; set; }
            public string Email { get; set; }
            public string Address { get; set; }
            public string Phone { get; set; } 
        }
    }
}
