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

        [Authorize]
        [HttpPut]
        public async Task<HttpResponseMessage> Update(CartModel model)
        {
            try
            {
                // Change game id to cart
                for (int i = 0; i < model.GamesInCart.Count; i++)
                {
                    model.GamesInCart[i].IsInCart = true;
                }
                int result = await service.UpdateAsync(AutoMapper.Mapper.Map<ICart>(model));

                if (result == 0)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "error");
                else
                    return Request.CreateResponse(HttpStatusCode.OK, "Added to cart");
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }  
    }

}
