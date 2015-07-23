using GameStore.WindowsApp.Model;
using GameStore.WindowsApp.Service.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;


namespace GameStore.WindowsApp.Service
{
    public class UserService : IUserService
    {
        private HttpClient client;
        private readonly string url;

        public UserService()
        {
            client = new HttpClient();
            url = Utilities.Constants.GAMESTORE_API + "/user/";
        }

        /// <summary>
        /// Find user by id and passwrd
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <returns>User</returns>
        public async Task<Model.User> FindAsync(string username, string password)
        {
            try
            {             
                // Add data to form
                List<KeyValuePair<string, string>> values = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("grant_type", "password"),
                    new KeyValuePair<string, string>("username", username),
                    new KeyValuePair<string, string>("password", password)
                };

                FormUrlEncodedContent content = new FormUrlEncodedContent(values);

                // Send post request with form data
                HttpResponseMessage response = await client.PostAsync("http://localhost:51229/GameStore/Token", content);
                string jsonString = await response.Content.ReadAsStringAsync();

                User user = JsonConvert.DeserializeObject<User>(jsonString);

                return user;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Task<bool> RegisterUser(Model.User user, string password)
        {
            throw new NotImplementedException();
        }

        public Task<Model.User> UpdateEmailOrUsernameAsync(Model.User user, string password)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdatePasswordAsync(string userId, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }
    }
}
