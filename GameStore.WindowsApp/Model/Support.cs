using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GameStore.WindowsApp.Model
{
    public class Support : INotifyPropertyChanged
    {
        #region Fields

        private Guid publisherId;
        private string email;
        private string address;
        private string phone;


        #endregion

        #region Proporties

        public Guid PublisherId
        {
            get { return publisherId; }
            set
            {
                publisherId = value;
                NotifyPropertyChanged();
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                NotifyPropertyChanged();
            }
        }

        public string Address
        {
            get { return address; }
            set
            {
                address = value;
                NotifyPropertyChanged();
            }
        }

        public string Phone
        {
            get { return phone; }
            set
            {
                phone = value;
                NotifyPropertyChanged();
            }
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
