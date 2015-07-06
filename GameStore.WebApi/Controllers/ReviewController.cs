using GameStore.Common;
using GameStore.Model.Common;
using GameStore.Service.Common;
using GameStore.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpPut]
        [Authorize]
        public async Task<HttpResponseMessage> Update(ReviewModel model)
        {
            try
            {
                ReviewModel result = AutoMapper.Mapper.Map<ReviewModel>(await service.UpdateAsync(AutoMapper.Mapper.Map<IReview>(model)));
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

        [HttpDelete]
        [Authorize]
        public async Task<HttpResponseMessage> Delete(ReviewModel model)
        {
            try
            {
                int result = await service.DeleteAsync(AutoMapper.Mapper.Map<IReview>(model));
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
