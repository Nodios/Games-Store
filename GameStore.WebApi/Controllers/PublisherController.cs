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
    [RoutePrefix("api/Publisher")]
    public class PublisherController : ApiController
    {
        private IPublisherService PublisherService;

        public PublisherController(IPublisherService service)
            :base()
        {
            PublisherService = service;
        }

        // GET: api/Publisher
        [Route("{pageNumber}/{pageSize}")]
        public async Task<HttpResponseMessage> Get(int pageNumber = 0, int pageSize = 0)
        {
            try
            {
                IEnumerable<IPublisher> result = await PublisherService.GetRangeAsync(new PublisherFilter(pageNumber, pageSize));

                if (result != null)
                    return Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<IEnumerable<PublisherModel>>(result));
                else
                    return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        //Get: api/Publisher/GetByName/Ea
        [HttpGet()]
        [Route("getByName/{name}/{pageNumber}/{pageSize}")]
        public async Task<HttpResponseMessage> GetByName(string name, int pageNumber, int pageSize)
        {
            try
            {
                if(pageSize < 1 || pageNumber < 1)
                {
                    pageNumber = 1;
                    pageSize = 1;
                }

                GenericFilter filter = new GenericFilter(pageNumber, pageSize);
                IEnumerable<IPublisher> result = await PublisherService.GetRangeAsync(name, filter);

                if (result != null)
                    return Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<IEnumerable<PublisherModel>>(result));
                else
                    return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadGateway, ex.Message);
            }
        }

        [HttpGet()]
        [Route("GetSupport/{id}")]
        public async Task<HttpResponseMessage> GetSupport(Guid id)
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
    }

   
}
