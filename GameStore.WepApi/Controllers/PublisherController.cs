using AutoMapper;
using GameStore.Model;
using GameStore.Model.Common;
using Service.Common;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace GameStore.WebApi.Controllers
{
    [RoutePrefix("api/Publisher")]
    public class PublisherController : ApiController
    {
        private ICompanyService CompanyService { get; set; }

        public PublisherController(ICompanyService service)
        {
            CompanyService = service;    
        }

        // GET: api/Publisher
        public async Task<HttpResponseMessage> Get()
        {
            var result = await CompanyService.GetRangeAsync();
            return Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<IEnumerable<PublisherModel>>(result));
        }

        // GET: api/Publisher/5
        public async Task<HttpResponseMessage> Get(int id)
        {
            var result = await CompanyService.GetAsync(id);
            return Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<PublisherModel>(result));
        }

        public class PublisherModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }

           
        }

        public class SupportModel
        {
            public int Id { get; set; }
            public string Email { get; set; }
            public string Address { get; set; }
            public string Phone { get; set; }

            // One to one
  
        }
    }
}
