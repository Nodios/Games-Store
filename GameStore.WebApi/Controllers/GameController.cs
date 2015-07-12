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
    [RoutePrefix("api/game")]
    public class GameController : ApiController
    {
        private IGamesService GamesService;

        public GameController(IGamesService gamesService)
        {
            GamesService = gamesService;
        }

        [Route("{pageNumber}/{pageSize}")]
        [HttpGet]
        public async Task<HttpResponseMessage> Get(int pageNumber = 0, int pageSize = 0)
        {
            try
            {
                IEnumerable<IGame> result = await GamesService.GetRangeAsync(new GameFilter(pageNumber, pageSize));
                if (result != null)
                    return Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<IEnumerable<GameModel>>(result));
                else
                    return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("getbyid/{id}")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetById(Guid id)
        {
            try
            {
                IGame result = await GamesService.GetAsync(id);
                if (result != null)
                    return Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<GameModel>(result));
                else
                    return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("getByName/{name}")]
        public async Task<HttpResponseMessage> GetByName(string name)
        {
            try
            {
                IEnumerable<GameModel> result = Mapper.Map<IEnumerable<GameModel>>(await GamesService.GetRangeAsync(name));
                if (result != null)
                    return Request.CreateResponse(HttpStatusCode.OK, result);
                else
                    return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("getRangeFromPublisherId/{id}")]
        public async Task<HttpResponseMessage> GetRangeFromPublisherId(Guid id)
        {
            try
            {
                IEnumerable<IGame> result = await GamesService.GetRangeAsync(id);
                if (result != null)
                    return Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<IEnumerable<GameModel>>(result));
                else
                    return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Authorize]
        [HttpDelete]
        public async Task<HttpResponseMessage> Delete(GameModel game)
        {
            try
            {
                int result = await GamesService.DeleteAsync(game.Id);

                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }

}
