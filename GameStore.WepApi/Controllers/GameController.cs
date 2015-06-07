using AutoMapper;
using GameStore.Common;
using GameStore.Model.Common;
using Service.Common;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace GameStore.WepApi.Controllers
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

        [Route("{id}")]
        public async Task<HttpResponseMessage> Get(int id)
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
                IGame result = await GamesService.GetAsync(name);
                if (result != null)
                    return Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<GameModel>(result));
                else
                    return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        
        [Route("getRangeFromPublisherId/{id}")]
        public async Task<HttpResponseMessage> GetRangeFromPublisherId(int id)
        {
            try
            {
                IEnumerable<IGame> result = await GamesService.GetRangeAsync(id);
                if (result != null)
                    return Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<IEnumerable<GameModel>>(result));
                else
                    return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        /// <summary>
        /// Game class
        /// </summary>
        public class GameModel
        {
            public int Id { get; set; }
            public int PublisherId { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string OsSupport { get; set; }
            public float? ReviewScore { get; set; }
            public string Genre { get; set; }
            public double Price { get; set; }
        }
    }
}
