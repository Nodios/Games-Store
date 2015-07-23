using GameStore.Common;
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
       private readonly IGameImageService service;

        public GameImageController(IGameImageService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Get collection of game images
        /// </summary>
        /// <returns>Resposne with collection of game images if found</returns>
        [Route("{gameId}/{pageNumber}/{pageSize}")]
        [HttpGet]
        public async Task<HttpResponseMessage> Get(Guid gameId, int pageNumber, int pageSize)
        {
            try
            {
                if(pageSize <= 0 || pageNumber <= 0)
                {
                    pageNumber = 1;
                    pageSize = 1;
                }

                GenericFilter filter = new GenericFilter(pageNumber, pageSize);
                IEnumerable<GameImageModel> result = AutoMapper.Mapper.Map<IEnumerable<GameImageModel>>(await service.GetRangeAsync(gameId, filter));

                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch ( Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }      
    } 
}
