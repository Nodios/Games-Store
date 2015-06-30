using AutoMapper;
using GameStore.Model.Common;
using GameStore.Service.Common;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
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
    
        [Route("{username}")]
        public async Task<HttpResponseMessage> Get(string username)
        {
            try
            {
                UserModel user = Mapper.Map<UserModel>(await userService.FindAsync(username));

                if (user == null)
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Can't find user with given id");
                else
                    return Request.CreateResponse(HttpStatusCode.OK, user);
            }
            catch (Exception ex )
            {
                
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("Register")]
        [HttpPost()]
        public async Task<HttpResponseMessage> Register(UserModel user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid action.");
                }
                bool isRegistered = await userService.RegisterUser(Mapper.Map<IUser>(user));

                if (isRegistered)
                    return Request.CreateResponse(HttpStatusCode.Created, "User registered");
                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Error while creating new user.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }



        // TODO 
        [Route("UpdateUserOrMail/{user}")]
        [Authorize]
        [HttpPut]
        public async Task<HttpResponseMessage> UpdatePasswordOrMail(UserModel user)
        {
            try
            {
                int result = await userService.UpdateEmailOrUsernameAsync(Mapper.Map<IUser>(user), user.PasswordHash);

                if (result == 1)
                    return Request.CreateResponse(HttpStatusCode.OK, "User updated.");
                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Update failed.");
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        public class UserModel : IdentityUser
        {
            public override string Id
            {
                get
                {
                    return base.Id;
                }
                set
                {
                    if (String.IsNullOrEmpty(value))
                        base.Id = Guid.NewGuid().ToString();
                    else
                        base.Id = value;
                }
            }

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
