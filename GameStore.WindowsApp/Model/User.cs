using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GameStore.WindowsApp.Model
{
    public class User : INotifyPropertyChanged
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

        public string PasswordHash
        {
            get { return passwordHash; }
            set { passwordHash = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public Cart Cart
        {
            get { return cart; }
            set { cart = value; }
        } 

        #endregion

        #region Notify property changed implementation

        /// <summary>
        /// Property changed event handler
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        // Notify that property is changed, called by set accessors
        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
