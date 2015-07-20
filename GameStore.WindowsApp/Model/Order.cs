using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GameStore.WindowsApp.Model
{
    public class Order : INotifyPropertyChanged
    {
        #region Fields

        private Guid id;
        private string userId;
        private string name;
        private string surname;
        private string deliveryAddress;
        private string contactEmail;
        private double amount; 

        #endregion

        #region Proporties

        public Guid Id
        {
            get { return id; }
            set
            {
                id = value;
                NotifyPropertyChanged();
            }
        }

        public string UserId
        {
            get { return userId; }
            set
            {
                userId = value;
                NotifyPropertyChanged();
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                NotifyPropertyChanged();
            }
        }

        public string Surname
        {
            get { return surname; }
            set
            {
                surname = value;
                NotifyPropertyChanged();
            }
        }

        public string DeliveryAddress
        {
            get { return deliveryAddress; }
            set
            {
                deliveryAddress = value;
                NotifyPropertyChanged();
            }
        }

        public string ContactEmail
        {
            get { return contactEmail; }
            set
            {
                contactEmail = value;
                NotifyPropertyChanged();
            }
        }

        public double Amount
        {
            get { return amount; }
            set { amount = value; }
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
