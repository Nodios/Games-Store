using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GameStore.WindowsApp.Model
{
    public class Game : INotifyPropertyChanged
    {
        #region Fields

        private Guid id;
        private Guid publisherId;
        private string name;
        private string description;
        private string osSupport;
        private float reviewScore;
        private string genre;
        private double price;
        private bool isInCart; 

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

        public Guid PublisherId
        {
            get { return publisherId; }
            set
            {
                publisherId = value;
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

        public string Description
        {
            get { return description; }
            set 
            { 
                description = value;
                NotifyPropertyChanged();
            }
        }

        public string OsSupport
        {
            get { return osSupport; }
            set
            { 
                osSupport = value;
                NotifyPropertyChanged();
            }
        }

        public float ReviewScore
        {
            get { return reviewScore; }
            set 
            {
                reviewScore = value;
                NotifyPropertyChanged();
            }
        }

        public string Genre
        {
            get { return genre; }
            set
            { 
                genre = value;
                NotifyPropertyChanged();
            }
        }

        public double Price
        {
            get { return price; }
            set 
            { 
                price = value;
                NotifyPropertyChanged();
            }
        }

        public bool IsInCart
        {
            get { return isInCart; }
            set 
            { 
                isInCart = value;
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
