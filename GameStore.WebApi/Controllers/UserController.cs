using AutoMapper;
using GameStore.Model.Common;
using GameStore.Service.Common;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private UserModel userForValidation;

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
                userForValidation = user;

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
        public async Task<HttpResponseMessage> Register(PostAndPutModel user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid action.");
                }

                // add password to user
                user.User.PasswordHash = user.Password;

                bool isRegistered = await userService.RegisterUser(Mapper.Map<IUser>(user.User), user.Password);

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
        public async Task<HttpResponseMessage> UpdatePasswordOrMail(PostAndPutModel user)
        {
            try
            {
                IUser result = await userService.UpdateEmailOrUsernameAsync(Mapper.Map<IUser>(user.User), user.Password);

                if (user == null)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Error while validating user. Update failed");
                else
                    return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        /// <summary>
        /// Keeps user model that holds user and password
        /// </summary>
        public class PostAndPutModel
        {
            public UserModel User { get; set; }
            public string Password { get; set; }
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
