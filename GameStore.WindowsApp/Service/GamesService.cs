using GameStore.WindowsApp.Model;
using GameStore.WindowsApp.Service.Common;
using GameStore.WindowsApp.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;


namespace GameStore.WindowsApp.Service
{
    class GamesService : IGamesService
    {
        private readonly HttpClient client;
        private readonly string url;

        /// <summary>
        /// The constructor
        /// </summary>
        public GamesService()
        {
            client = new HttpClient();
            url = Constants.GAMESTORE_API + "/game/";
        }

        public async Task<Model.Game> GetAsync(Guid id)
        {
            try
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, new Uri(url + "/getById/" + id));
                HttpResponseMessage response = await client.SendAsync(request);
                string jsonString = await response.Content.ReadAsStringAsync();

                Game game = JsonConvert.DeserializeObject<Game>(jsonString);

                return game;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public async Task<IEnumerable<Model.Game>> GetRangeAsync(string name, Utilities.GenericFilter filter)
        {
            try
            {
                HttpRequestMessage request = new HttpRequestMessage
                    (HttpMethod.Get, new Uri(url + "/getByName/" + name + "/" + filter.PageNumber + "/" + filter.PageSize));
                HttpResponseMessage response = await client.SendAsync(request);
                string jsonString = await response.Content.ReadAsStringAsync();

                IEnumerable<Game> games = JsonConvert.DeserializeObject <IEnumerable<Game>>(jsonString);

                return games;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public async Task<IEnumerable<Model.Game>> GetRangeAsync(Utilities.GenericFilter filter = null)
        {
            try
            {
                if (filter == null)
                    filter = new GenericFilter(1, 5);

                HttpRequestMessage request = new HttpRequestMessage
                    (HttpMethod.Get, new Uri(url + filter.PageNumber + "/" + filter.PageSize));

                HttpResponseMessage response = await client.SendAsync(request);
                string jsonString = await response.Content.ReadAsStringAsync();

                IEnumerable<Game> games = JsonConvert.DeserializeObject<IEnumerable<Game>>(jsonString);

                return games;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public Task<IEnumerable<Model.Game>> GetRangeAsync(Guid publisherId, Utilities.GenericFilter filter = null)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(params Guid[] id)
        {
            throw new NotImplementedException();
        }
    }
}
