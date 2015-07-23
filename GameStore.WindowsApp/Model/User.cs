using GalaSoft.MvvmLight;

namespace GameStore.WindowsApp.Model
{
    public class User : ObservableObject
    {
        #region Fields

        private string id;
        private string userName;
        private string passwordHash;
        private string email;
        private Cart cart;

        #endregion

        #region Proporties

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        /// <summary>
        /// Implements notify property changed
        /// </summary>
        public string PasswordHash
        {
            get { return passwordHash; }
            set { Set(() => this.PasswordHash, ref passwordHash, value); }
        }

        /// <summary>
        /// Implements notify property changed
        /// </summary>
        public string Email
        {
            get { return email; }
            set { Set(() => this.Email, ref email, value); }
        }

        /// <summary>
        /// Implements notify property changed
        /// </summary>
        public Cart Cart
        {
            get { return cart; }
            set { Set(() => this.Cart, ref cart, value); }
        } 

        #endregion

       
    }
}
