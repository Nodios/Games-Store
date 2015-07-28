using GameStore.WindowsApp.Service.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.WindowsApp.Service
{
    public class CartService : ICartService
    {
        private readonly HttpClient client;
        private readonly string url;

        public CartService()
        {
            client = new HttpClient();
            url = Utilities.Constants.GAMESTORE_API + "/cart/";
        }

        public Task<Model.Cart> GetAsync(string userId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sends update request
        /// </summary>
        /// <param name="cart">Cart model</param>
        /// <returns>1 if success, 0 otherwise</returns>
        public async Task<int> UpdateAsync(Model.Cart cart)
        {
            try
            {
                // Serialize to json
                string jsonContent = JsonConvert.SerializeObject(cart);

                // Add content and headers
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, url + "update/" + cart.UserId);
                request.Headers.Add("Authorization", "Bearer " + GameStore.WindowsApp.Common.UserInfo.Token);
                request.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                // PutAsync
                HttpResponseMessage response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                    return 1;
                else
                    return 0;              
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
    }
}
