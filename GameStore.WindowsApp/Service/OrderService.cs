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
    public class OrderService : IOrderService
    {
        private readonly HttpClient client;
        private readonly string url;

        public OrderService()
        {
            client = new HttpClient();
            url = Constants.GAMESTORE_API + "/order/";
        }

        public Task<ICollection<Model.Order>> GetAsync(string userId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds order
        /// </summary>
        /// <param name="order">Order to add</param>
        /// <returns>Order</returns>
        public async Task<Model.Order> AddAsync(Model.Order order)
        {
            try
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);

                // Authorization
                request.Headers.Add("Authorization", "Bearer " + GameStore.WindowsApp.Common.UserInfo.Token);

                // Content
                string jsonContent = JsonConvert.SerializeObject(order);
                StringContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                request.Content = content;

                // Send
                HttpResponseMessage response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                    return order;
                else
                    return null;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
    }
}
