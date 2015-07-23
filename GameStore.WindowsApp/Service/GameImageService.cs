using GameStore.WindowsApp.Model;
using GameStore.WindowsApp.Service.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;


namespace GameStore.WindowsApp.Service
{
    public class GameImageService : IGameImageService
    {
        private readonly HttpClient client;
        private readonly string url;

        public GameImageService()
        {
            client = new HttpClient();
            url = Utilities.Constants.GAMESTORE_API + "/gameImage/";
        }

        /// <summary>
        /// Get image for game
        /// </summary>
        /// <param name="gameId">Game id</param>
        /// <returns>Game image</returns>
        public async Task<Model.GameImage> GetAsync(Guid gameId)
        {
            try
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, new Uri(url + gameId + "/1/1/"));
                HttpResponseMessage response = await client.SendAsync(request);
                string jsonString = await response.Content.ReadAsStringAsync();

                List<GameImage> images = JsonConvert.DeserializeObject<List<GameImage>>(jsonString);

                if (images == null || images.Count() <= 0)
                    throw new Exception("Server error occured while trying to fetch gama image.");
                else
                    return images[0];

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
    }
}
