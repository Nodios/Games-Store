using AutoMapper;
using GameStore.Common;
using GameStore.Model.Common;
using GameStore.Service.Common;
using GameStore.WebApi.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace GameStore.WebApi.Controllers
{
    [RoutePrefix("api/order")]
    [Authorize]
    public class OrderController : ApiController
    {
        private readonly IOrderService service;

        public OrderController(IOrderService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Get collection of orders that belong to user
        /// </summary>
        /// <param name="userId">User id to search by</param>
        /// <param name="pageNumber">Page number</param>
        /// <param name="pageSize">Size of collection</param>
        /// <returns>Response message with collection of orders</returns>
        [HttpGet]
        [Route("{userId}/{pageNumber}/{pageSize}")]
        public async Task<HttpResponseMessage> Get(string userId, int pageNumber, int pageSize)
        {
            try
            {
                if (pageNumber < 1 || pageSize < 1)
                {
                    pageSize = 1;
                    pageNumber = 1;
                }
                GenericFilter filter = new GenericFilter(pageNumber, pageSize);
                ICollection<OrderModel> result = Mapper.Map<ICollection<OrderModel>>( await service.GetAsync(userId, filter));

                if (result == null)
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                else
                    return Request.CreateResponse(HttpStatusCode.OK, result);
                
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        /// <summary>
        /// Add new order
        /// </summary>
        /// <param name="order">Order</param>
        /// <returns>Response message with added order</returns>
        [HttpPost]
        public async Task<HttpResponseMessage> Add(OrderModel order)
        {
            try
            {
                OrderModel result = Mapper.Map<OrderModel>(await service.AddAsync(Mapper.Map<IOrder>(order)));

                if (result == null)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Couldn't add order to database. Please try again.");
                else
                    return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
