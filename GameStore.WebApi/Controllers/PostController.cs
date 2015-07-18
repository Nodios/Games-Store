using AutoMapper;
using GameStore.Common;
using GameStore.Model.Common;
using GameStore.Service.Common;
using GameStore.WebApi.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace GameStore.WebApi.Controllers
{
    [RoutePrefix("api/post")]
    public class PostController : ApiController
    {
        private IPostService PostService;

        #region Constructor

        public PostController(IPostService service)
        {
            if (service == null)
                throw new ArgumentNullException("service cannot be null");

            PostService = service;
        }

        #endregion

        #region Public methods

        [HttpGet]
        [Route("{id}/{pageNumber}/{pageSize}")]
        public async Task<HttpResponseMessage> Get(Guid id, int pageNumber, int pageSize)
        {
            try
            {
                if (pageSize < 1 || pageNumber < 1)
                {
                    pageNumber = 1;
                    pageSize = 1;
                }

                GenericFilter filter = new GenericFilter(pageNumber, pageSize);
                IEnumerable<PostModel> result = Mapper.Map<IEnumerable<PostModel>>(await PostService.GetPosts(id, filter));

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
        /// Add new post
        /// </summary>
        [Authorize]
        [HttpPost]
        public async Task<HttpResponseMessage> Insert(PostModel model)
        {
            try
            {
                int result = await PostService.AddPost(Mapper.Map<IPost>(model));
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

        #endregion

    }

}
