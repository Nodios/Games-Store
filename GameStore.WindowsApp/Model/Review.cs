using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.WindowsApp.Model
{
    public class Review : INotifyPropertyChanged
    {
        #region Notify property changed implementation

        /// <summary>
        /// Property changed event handler
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        // Notify that property is changed, called by set accessors
        public void NotifyPropertyChanged([CallerMemberName] string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
