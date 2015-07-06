using GameStore.Model.Common;
using GameStore.Service.Common;
using GameStore.WebApi.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace GameStore.WebApi.Controllers
{
    [RoutePrefix("api/cart")]
    public class CartController : ApiController
    {
        ICartService service;

        public CartController(ICartService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("{userId}")]
        public async Task<HttpResponseMessage> Get(string userId)
        {
            try
            {
                CartModel cart = AutoMapper.Mapper.Map<CartModel>(await service.GetAsync(userId));
                
                if (cart == null)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Error");
                else
                    return Request.CreateResponse(HttpStatusCode.OK, cart);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("Update")]
        [Authorize]
        [HttpPut]
        public async Task<HttpResponseMessage> Update(CartModel model)
        {
            try
            {
                CartModel result = AutoMapper.Mapper.Map<CartModel>(await service.UpdateAsync(AutoMapper.Mapper.Map<ICart>(model)));

                if(result == null)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "error");
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
