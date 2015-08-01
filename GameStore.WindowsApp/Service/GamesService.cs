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

        /// <summary>
        /// Get game by id
        /// </summary>
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

        /// <summary>
        /// Get games 
        /// </summary>
        /// <param name="name">game name or part of name</param>
        /// <param name="filter">filter options</param>
        /// <returns>Collection of games</returns>
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

        /// <summary>
        /// Get collection of games 
        /// </summary>
        /// <param name="filter">Filter options</param>
        /// <returns>Collection of games</returns>
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

        /// <summary>
        /// Delete game 
        /// </summary>
        /// <param name="id">Game id</param>
        /// <returns>True is succeed , false otherwise</returns>
        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, url + "delete/" + id);
                request.Headers.Add("Authorization", "Bearer " + GameStore.WindowsApp.Common.UserInfo.Token);

                HttpResponseMessage response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public Task<bool> DeleteAsync(params Guid[] id)
        {
            throw new NotImplementedException();
        }
    }
}
