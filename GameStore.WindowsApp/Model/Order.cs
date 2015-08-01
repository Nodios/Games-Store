using GalaSoft.MvvmLight;
using System;

namespace GameStore.WindowsApp.Model
{
    public class Order : ObservableObject
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
        }

        public string UserId
        {
            get { return userId; }
            set { Set(() => this.UserId, ref userId, value); }
            
        }

        public string Name
        {
            get { return name; }
            set { Set(() => this.Name, ref name, value); }
        }

        public string Surname
        {
            get { return surname; }
            set { Set(() => this.Surname, ref surname, value); }
        }

        public string DeliveryAddress
        {
            get { return deliveryAddress; }
            set { Set(() => this.DeliveryAddress, ref deliveryAddress, value); }
        }

        public string ContactEmail
        {
            get { return contactEmail; }
            set { Set(() => this.ContactEmail, ref contactEmail, value); }
        }

        public double Amount
        {
            get { return amount; }
            set { Set(() => this.Amount, ref amount, value); }
        }

        #endregion

    }
}
