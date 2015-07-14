using AutoMapper;
using GameStore.Model.Common;
using GameStore.Service.Common;
using GameStore.WebApi.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace GameStore.WebApi.Controllers
{
    [RoutePrefix("gamestore/api")]
    [Authorize]
    public class OrderController : ApiController
    {
        private IOrderService service;

        public OrderController(IOrderService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<HttpResponseMessage> Get(string userId)
        {
            try
            {
                ICollection<OrderModel> result = Mapper.Map<ICollection<OrderModel>>( await service.GetAsync(userId));

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
