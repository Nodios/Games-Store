
namespace GameStore.WindowsApp.Common
{
    internal static class UserInfo
    {
        private static string username;
        private static string id;
        private static string token;

        /// <summary>
        /// Used to store username
        /// </summary>
        internal static string Username
        {
            get { return username; }
            set { username = value; }
        }

        /// <summary>
        /// Store user id
        /// </summary>
        internal static string Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// Store authorization token
        /// </summary>
        internal static string Token
        {
            get { return token; }
            set { token = value; }
        }
    }
}
