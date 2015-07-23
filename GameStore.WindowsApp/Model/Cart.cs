using GalaSoft.MvvmLight;
using System.Collections.Generic;

namespace GameStore.WindowsApp.Model
{
    public class Cart : ObservableObject
    {
        public string UserId { get; set; }
        public virtual IList<Game> GamesInCart { get; set; }

        //private string userId;
        //private ICollection<Game> gamesInCart;

        //public string UserId
        //{
        //    get { return this.userId; }
        //    set
        //    {
        //        this.userId = value;
        //        NotifyPropertyChanged();
        //    }
        //}

        //public ICollection<Game> GamesInCart
        //{
        //    get { return this.gamesInCart; }
        //    set
        //    {
        //        this.gamesInCart = value;
        //        NotifyPropertyChanged();
        //    }
        //}

        //#region Notify property changed implementation

        ///// <summary>
        ///// Property changed event handler
        ///// </summary>
        //public event PropertyChangedEventHandler PropertyChanged;

        //// Notify that property is changed, called by set accessors
        //private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        //{
        //    if (PropertyChanged != null)
        //        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        //}

        //#endregion
    }
}
