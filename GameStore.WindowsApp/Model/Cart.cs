using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.WindowsApp.Model
{
    public class Cart : INotifyPropertyChanged
    {
        private string userId;
        private ICollection<Game> gamesInCart;

        public string UserId
        {
            get { return this.userId; }
            set
            {
                this.userId = value;
                NotifyPropertyChanged();
            }
        }

        public ICollection<Game> GamesInCart
        {
            get { return this.gamesInCart; }
            set
            {
                this.gamesInCart = value;
                NotifyPropertyChanged();
            }
        }

        #region Notify property changed implementation

        /// <summary>
        /// Property changed event handler
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        // Notify that property is changed, called by set accessors
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
