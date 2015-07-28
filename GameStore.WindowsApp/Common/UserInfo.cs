namespace GameStore.WindowsApp.Common
{
    delegate void Notify();

    internal static class UserInfo
    {
        private static string username;
        private static string id;
        private static string token;

        public static event Notify OnUserNameChange;

        /// <summary>
        /// Used to store username
        /// </summary>
        internal static string Username
        {
            get { return username; }
            set 
            { 
                username = value;
                Notify();
            }
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

        private static void Notify()
        {
            if (OnUserNameChange != null)
                OnUserNameChange();
        }
    }
}