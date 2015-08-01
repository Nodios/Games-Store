using GalaSoft.MvvmLight;
using System;

namespace GameStore.WindowsApp.Model
{
    public class Support : ObservableObject
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
            set { Set(() => this.PublisherId, ref publisherId, value); }
        }

        public string Email
        {
            get { return email; }
            set { Set(() => this.Email, ref email, value); }
        }

        public string Address
        {
            get { return address; }
            set { Set(() => this.Address, ref address, value); }
        }

        public string Phone
        {
            get { return phone; }
            set { Set(() => this.Phone, ref phone, value); }
        }

        #endregion      
    }
}
