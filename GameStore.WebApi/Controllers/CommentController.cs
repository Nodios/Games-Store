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
    [RoutePrefix("api/comment")]
    public class CommentController : ApiController
    {
        ICommentService service;

        public CommentController(ICommentService service)
        {
            this.service = service;
        }


        /// <summary>
        /// Get collection of comments that belong to post
        /// </summary>
        /// <param name="id">Post id</param>
        /// <param name="pageNumber">Page number</param>
        /// <param name="pageSize">Size of collection</param>
        /// <returns>Collection of comments if success</returns>
        [HttpGet]
        [Route("{postId}/{pageNumber}/{pageSize}")]
        public async Task<HttpResponseMessage> Get(Guid postId, int pageNumber, int pageSize)
        {
            try
            {
                if (pageSize < 1 || pageNumber < 1)
                {
                    pageNumber = 1;
                    pageSize = 1;
                }

                GenericFilter filter = new GenericFilter(pageNumber, pageSize);
                IEnumerable<CommentModel> result = Mapper.Map<IEnumerable<CommentModel>>(await service.GetRangeAsync(postId, filter));

                if (result != null)
                    return Request.CreateResponse(HttpStatusCode.Created, result);
                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }


        /// <summary>
        /// Add new comment
        /// </summary>
        [Authorize]
        [HttpPost]
        public async Task<HttpResponseMessage> Insert(CommentModel model)
        {
            try
            {
                int result = await service.AddAsync(Mapper.Map<IComment>(model));
                if (result >= 1)
                    return Request.CreateResponse(HttpStatusCode.Created, model);
                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
