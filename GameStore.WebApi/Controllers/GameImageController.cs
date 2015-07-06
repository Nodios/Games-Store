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
    [RoutePrefix("api/gameImage")]
    public class GameImageController : ApiController
    {
        IGameImageService service;

        public GameImageController(IGameImageService service)
        {
            this.service = service;
        }

        [Route("{gameId}")]
        [HttpGet]
        public async Task<HttpResponseMessage> Get(Guid gameId)
        {
            try
            {
                IEnumerable<GameImageModel> result = AutoMapper.Mapper.Map<IEnumerable<GameImageModel>>(await service.GetRangeAsync(gameId));

                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch ( Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }      
    } 
}
