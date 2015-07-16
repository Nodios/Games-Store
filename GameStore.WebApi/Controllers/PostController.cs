﻿using AutoMapper;
using GameStore.Model.Common;
using GameStore.Service.Common;
using GameStore.WebApi.Models;
using System;
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

       
        [Authorize]
        [HttpPost]
        public async Task<HttpResponseMessage> Insert(PostModel model)
        {
            try
            {
                int result = await PostService.AddPost(Mapper.Map<IPost>(model));
                if (result == 1)
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
