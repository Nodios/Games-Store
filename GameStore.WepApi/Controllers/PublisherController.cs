﻿using AutoMapper;
using GameStore.Common;
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
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // GET: api/Publisher/5
        [Route("{id}")]
        public async Task<HttpResponseMessage> Get(Guid id)
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
        [Route("getByName/{name}")]
        public async Task<HttpResponseMessage> GetByName(string name)
        {
            try
            {
                IEnumerable<IPublisher> result = await PublisherService.GetRangeAsync(name);

                if (result != null)
                    return Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<IEnumerable<PublisherModel>>(result));
                else
                    return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            catch(Exception ex)
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

        /// <summary>
        /// Publisher class
        /// </summary>
        public class PublisherModel
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
        }

        /// <summary>
        /// Support class
        /// </summary>
        public class SupportModel
        {
            public Guid PublisherId { get; set; }
            public string Email { get; set; }
            public string Address { get; set; }
            public string Phone { get; set; } 
        }
    }
}
