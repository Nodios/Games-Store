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
        /// Gets user by username
        /// </summary>
        public async Task<User> GetAsync(string username)
        {
            try
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url + username);

                HttpResponseMessage response = await client.SendAsync(request);

                User user = null;
                string content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                    user = JsonConvert.DeserializeObject<User>(content);

                return user;
            }
            catch (Exception ex)
            {

                throw ex;
            }
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

        /// <summary>
        /// Updates user name or email
        /// </summary>
        /// <param name="user">User to update</param>
        /// <param name="password">Password</param>
        /// <returns>Retunr user</returns>
        public async Task<Model.User> UpdateEmailOrUsernameAsync(Model.User user, string password)
        {
            try
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, url + "UpdateUserOrMail/" + GameStore.WindowsApp.Common.UserInfo.Id);

                // Content and authorization
                UserEntityToSend modelToSend = new UserEntityToSend(user, password);
                string toSend = JsonConvert.SerializeObject(modelToSend);
                request.Content = new StringContent(toSend, Encoding.UTF8, "application/json");
                request.Headers.Add("Authorization", "Beaerer " + GameStore.WindowsApp.Common.UserInfo.Token);

                // Response
                HttpResponseMessage response = await client.SendAsync(request);

                // Deserialize response
                string result = await response.Content.ReadAsStringAsync();
                User userResult = JsonConvert.DeserializeObject<User>(result);

                return userResult;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Updates user passowrd
        /// </summary>
        /// <param name="userId">user id</param>
        /// <param name="oldPassword">old password</param>
        /// <param name="newPassword">new password</param>
        /// <returns>True is success</returns>
        public async Task<bool> UpdatePasswordAsync(string userId, string oldPassword, string newPassword)
        {
            try
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, url + "UpdatePassword/" + userId);

                // Content and authorization
                ChangeUserPasswordModel modelToSend = new ChangeUserPasswordModel(oldPassword, newPassword);
                string toSend = JsonConvert.SerializeObject(modelToSend);
                request.Content = new StringContent(toSend, Encoding.UTF8, "application/json");
                request.Headers.Add("Authorization", "Bearer " + GameStore.WindowsApp.Common.UserInfo.Token);

                // Response
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



        #region User entities

        /// <summary>
        /// Keeps user model that holds user and password
        /// </summary>
        class UserEntityToSend
        {
            public string Password { get; private set; }
            public User User { get; private set; }

            public UserEntityToSend(User user, string password)
            {
                User = user;
                Password = password;
            }
        }

        /// <summary>
        /// Keeps model data for changing user password
        /// </summary>
        public class ChangeUserPasswordModel
        {
            public string OldPassword { get; private set; }
            public string NewPassword { get; private set; }

            public ChangeUserPasswordModel(string oldPassword, string newPassword)
            {
                OldPassword = oldPassword;
                NewPassword = newPassword;
            }
        }

        #endregion
    }
}
