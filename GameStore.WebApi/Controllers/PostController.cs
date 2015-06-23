using AutoMapper;
using GameStore.Model.Common;
using GameStore.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace GameStore.WebApi.Controllers
{
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

        /*
        [Route("{gameId}/{pageNumber}/{pageSize}")]
        public async Task<HttpResponseMessage> Get(Guid gameId = new Guid(), int pageNumber = 0, int pageSize = 0)
        {
            try
            {
                IEnumerable<IPost> result = await PostService.GetPosts(gameId, new Common.PostFilter(pageNumber, pageSize));

                if (result != null)
                    return Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<IEnumerable<PostModel>>(result));
                else
                    return Request.CreateResponse(HttpStatusCode.NotFound);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }


        [Route("{post}")]
        [HttpPost]
        public async Task<HttpResponseMessage> Post(PostModel post)
        {
            try
            {
                int result = await PostService.AddPost(Mapper.Map<IPost>(post));
                if (result == 1)
                    return Request.CreateResponse(HttpStatusCode.Created, post);
                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        */

        #endregion


        public class PostModel
        {
            public Guid Id { get; set; }
            public int VotesUp { get; set; }
            public int VotesDown { get; set; }
            public string Description { get; set; }
            public string Title { get; set; }
            public Guid GameId { get; set; }
            public Guid? UserId { get; set; }
        }
    }
}
