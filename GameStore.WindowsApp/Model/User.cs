using GalaSoft.MvvmLight;
using System;

namespace GameStore.WindowsApp.Model
{
    public class User : ObservableObject
    {
        #region Fields

        private string id;
        private string access_token;
        private string userName;
        private string passwordHash;
        private string email;
        private Cart cart;

        #endregion

        #region Proporties

        public string Id
        {
            get { return id; }
            set
            {
                if (String.IsNullOrEmpty(id))
                    id = value;
            }
        }

        public string Access_token
        {
            get { return access_token; }
            set
            {
                if (String.IsNullOrEmpty(access_token))
                    access_token = value;
            }
        }

        public string UserName
        {
            get { return userName; }
            set
            {
                if (String.IsNullOrEmpty(userName))
                    userName = value;
            }
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

        #region Constructor

        public User()
        {
            Cart = new Cart(Id);
        }
        #endregion


    }
}
