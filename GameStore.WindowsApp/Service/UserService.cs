using GameStore.WindowsApp.Common;
using GameStore.WindowsApp.Model;
using GameStore.WindowsApp.Service.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Storage;



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

                UserInfo.Id = user.Id;
                UserInfo.Token = user.Access_token;
                UserInfo.Username = user.UserName;

                return user;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Register new user
        /// </summary>
        /// <param name="user">User to register</param>
        /// <param name="password">password</param>
        /// <returns>Bool on success</returns>
        public async Task<bool> RegisterUser(Model.User user, string password)
        {
            try
            {
                UserEntityToSend toSend = new UserEntityToSend(user, password);

                string jsonContent = JsonConvert.SerializeObject(toSend);

                HttpResponseMessage response = await client.PostAsync(url + "register", new StringContent(jsonContent, Encoding.UTF8, "application/json"));

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

        public Task<Model.User> UpdateEmailOrUsernameAsync(Model.User user, string password)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdatePasswordAsync(string userId, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        class UserEntityToSend
        {
            private User user;
            private string password;

            public UserEntityToSend(User user, string password)
            {
                this.user = user;
                this.password = password;
            }

            public string Password
            {
                get { return password; }
            }

            public User User
            {
                get { return user; }
            }


        }
    }
}
