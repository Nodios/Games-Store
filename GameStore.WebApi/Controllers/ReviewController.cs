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
    [RoutePrefix("api/Review")]
    public class ReviewController : ApiController
    {
        IReviewService service;

        public ReviewController(IReviewService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Get collection of reviews, belonging to a game
        /// </summary>
        /// <param name="GameId">Game id to search by</param>
        /// <param name="pageNumber">Page number</param>
        /// <param name="pageSize">Size of collection</param>
        /// <returns>Response message with collection of reviews</returns>
        [HttpGet]
        [Route("{gameId}/{pageNumber}/{pageSize}")]
        public async Task<HttpResponseMessage> Get(Guid GameId, int pageNumber, int pageSize)
        {
            try
            {
                GenericFilter filter = new GenericFilter(pageNumber, pageSize);
                IEnumerable<ReviewModel> result = AutoMapper.Mapper.Map<IEnumerable<ReviewModel>>(await service.GetAsync(GameId, filter));

                if (result == null)
                    return Request.CreateResponse(HttpStatusCode.OK, "No result.");
                else
                    return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        /// <summary>
        /// Add new review
        /// </summary>
        /// <returns>Model</returns>
        [HttpPost]
        [Authorize]
        public async Task<HttpResponseMessage> Insert(ReviewModel model)
        {
            try
            {
                ReviewModel result = AutoMapper.Mapper.Map<ReviewModel>(await service.AddAsync(AutoMapper.Mapper.Map<IReview>(model)));
                if (result == null)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Failed.");
                else
                    return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        /// <summary>
        /// Update review
        /// </summary>
        /// <param name="id">Review id</param>
        /// <param name="model">Updated review</param>
        /// <returns>Updated review</returns>
        [HttpPut]
        [Authorize]
        [Route("{id}")]
        public async Task<HttpResponseMessage> Update(Guid id, ReviewModel model)
        {
            try
            {
                ReviewModel result = AutoMapper.Mapper.Map<ReviewModel>(await service.UpdateAsync(AutoMapper.Mapper.Map<IReview>(model)));
                if (result == null)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Error while updating review.");
                else
                    return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        /// <summary>
        /// Delete review
        /// </summary>
        [HttpDelete]
        [Authorize]
        [Route("{id}")]
        public async Task<HttpResponseMessage> Delete(Guid id)
        {
            try
            {
                int result = await service.DeleteAsync(id);
                if (result == 0)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Failed.");
                else
                    return Request.CreateResponse(HttpStatusCode.OK, "Review deleted");
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

       
    }
}
