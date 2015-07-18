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

        #region Get

        /// <summary>
        /// Get collection of games
        /// </summary>
        /// <returns>Response message with collection of games on success</returns>
        [Route("{pageNumber}/{pageSize}")]
        [HttpGet]
        public async Task<HttpResponseMessage> Get(int pageNumber = 0, int pageSize = 0)
        {
            try
            {
                IEnumerable<IGame> result = await GamesService.GetRangeAsync(new GenericFilter(pageNumber, pageSize));
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

        /// <summary>
        /// Get game by id
        /// </summary>
        /// <param name="id">Id to search by</param>
        /// <returns>response message with game</returns>
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

        /// <summary>
        /// Gets collection of games by part of name
        /// </summary>
        /// <param name="name">String to searh by</param>
        /// <param name="pageNumber">Page number</param>
        /// <param name="pageSize">Page size, number of times to get</param>
        /// <returns>Response message with collection of games </returns>
        [Route("getByName/{name}/{pageNumber}/{pageSize}")]
        public async Task<HttpResponseMessage> GetByName(string name, int pageNumber, int pageSize)
        {
            try
            {
                GenericFilter filter = new GenericFilter(pageNumber, pageSize);
                IEnumerable<GameModel> result = Mapper.Map<IEnumerable<GameModel>>(await GamesService.GetRangeAsync(name, filter));
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

        /// <summary>
        /// Gets collection of games 
        /// </summary>
        /// <param name="id">Guid publisher id</param>
        /// <param name="pageNumber">int page number</param>
        /// <param name="pageSize">int page size</param>
        /// <returns>HttpResponse with filtered collection of GameModels</returns>
        [Route("getRangeFromPublisherId/{id}/{pageNumber}/{pageSize}")]
        public async Task<HttpResponseMessage> GetRangeFromPublisherId(Guid id, int pageNumber, int pageSize)
        {
            try
            {
                GenericFilter filter;

                if (pageNumber <= 0 && pageSize <= 0)
                    filter = null;
                else
                    filter = new GenericFilter(pageNumber, pageSize);

                IEnumerable<IGame> result = await GamesService.GetRangeAsync(id, filter);
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

        #endregion

        #region Delete 

        /// <summary>
        /// Deletes game
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>Resposne message</returns>
        [Authorize]
        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<HttpResponseMessage> Delete(Guid id)
        {
            try
            {
                int result = await GamesService.DeleteAsync(id);

                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        /// <summary>
        /// Deletes collection of games
        /// </summary>
        /// <param name="id">Collection of id's</param>
        /// <returns>Resposne message</returns>
        [Authorize]
        [HttpDelete]
        [Route("DeleteMultiple")]
        public async Task<HttpResponseMessage> Delete(Guid[] id)
        {
            try
            {
                int result = await GamesService.DeleteAsync(id);

                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        } 

        #endregion

    }

}
