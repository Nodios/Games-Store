using AutoMapper;
using GameStore.Model;
using GameStore.Model.Common;
using GameStore.Service.Common;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace GameStore.WebApi.Controllers
{
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        private IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<HttpResponseMessage> Get()
        {
            UserModel user = new UserModel()
            {
                UserName = "luka712",
                Email = "luka712@hotmail.com",
                PasswordHash = "luka071289",
                Password = "luka071289",
                ConfirmPassword = "luka071289"
            };
            var result = await userService.RegisterUser(Mapper.Map<IUser>(user));
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route("Register")]
        [HttpPost]
        public async Task<HttpResponseMessage> PostRegister(UserModel user)
        {
            try
            {
                bool isRegistered = await userService.RegisterUser(Mapper.Map<IUser>(user));

                if (isRegistered)
                    return Request.CreateResponse(HttpStatusCode.Created, "User registered");
                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        public class UserModel : IdentityUser
        {
            public string Password { get; set; }
            public string ConfirmPassword { get; set; }

            // One to one 
            public virtual IInfo Info { get; set; }
            public virtual ICart Cart { get; set; }

            // One to many
            public virtual ICollection<IGame> Games { get; set; }
            public virtual ICollection<IComment> Comments { get; set; }
            public virtual ICollection<IPost> Posts { get; set; }
            public virtual ICollection<IReview> Reviews { get; set; }         
        }
    }
}
