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
        private readonly ICommentService service;

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
        [Route("Insert")]
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

        /// <summary>
        /// Update comment
        /// </summary>
        /// <param name="id">Comment id</param>
        /// <param name="model">Model to upadte</param>
        /// <returns>Http response</returns>
        [Authorize]
        [HttpPut]
        [Route("Update/{id}")]
        public async Task<HttpResponseMessage> Update(Guid id, CommentModel model)
        {
            try
            {
                int result = await service.UpdateAsync(Mapper.Map<IComment>(model));
                if (result >= 1)
                    return Request.CreateResponse(HttpStatusCode.OK, model);
                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Error while trying to edit comment.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        /// <summary>
        /// Delete comment
        /// </summary>
        /// <param name="id">Comment id</param>
        /// <returns>Http response</returns>
        [Authorize]
        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<HttpResponseMessage> Update(Guid id)
        {
            try
            {
                int result = await service.DeleteAsync(id);
                if (result >= 1)
                    return Request.CreateResponse(HttpStatusCode.OK, "Comment removed.");
                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Error while trying to delete comment.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
