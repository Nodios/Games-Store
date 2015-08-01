using GameStore.WindowsApp.Model;
using GameStore.WindowsApp.Service.Common;
using GameStore.WindowsApp.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.WindowsApp.Service
{
    public class PublisherService : IPublisherService
    {
        private readonly HttpClient client;
        private readonly string url;

        public PublisherService()
        {
            client = new HttpClient();
            url = Constants.GAMESTORE_API + "/publisher/";
        }

        /// <summary>
        /// Get collection of games
        /// </summary>
        public async Task<IEnumerable<Model.Publisher>> GetRangeAsync(string name, Utilities.GenericFilter filter)
        {
            try
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url + "/searchbyname/"
                    + name + "/" + filter.PageNumber + "/" + filter.PageSize);

                HttpResponseMessage content = await client.SendAsync(request);
                string json = await content.Content.ReadAsStringAsync();

                IEnumerable<Publisher> result = JsonConvert.DeserializeObject<IEnumerable<Publisher>>(json);

                return result;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        /// <summary>
        /// Get collection of games by name
        /// </summary>
        public Task<Model.Support> GetSupportAsync(Guid id)
        {
            try
            {
                return null;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        /// <summary>
        /// Get collection of games by name
        /// </summary>
        public async Task<IEnumerable<Model.Publisher>> GetRangeAsync(Utilities.GenericFilter filter)
        {
            try
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url + filter.PageNumber + "/" + filter.PageSize);

                HttpResponseMessage content = await client.SendAsync(request);
                string json = await content.Content.ReadAsStringAsync();

                IEnumerable<Publisher> result = JsonConvert.DeserializeObject<IEnumerable<Publisher>>(json);

                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
