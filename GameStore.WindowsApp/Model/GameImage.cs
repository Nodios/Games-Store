using GalaSoft.MvvmLight;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GameStore.WindowsApp.Model
{
    public class GameImage : ObservableObject
    {
        public Guid Id { get; set; }
        public Guid GameId { get; set; }
        public byte[] Content { get; set; }

        //#region Fields

        //private Guid id;
        //private Guid gameId;
        //private byte[] content;

        //#endregion

        //#region Proporties

        //public Guid Id
        //{
        //    get { return id; }
        //    set
        //    {
        //        id = value;
        //        NotifyPropertyChanged();
        //    }
        //}

        //public Guid GameId
        //{
        //    get { return gameId; }
        //    set
        //    {
        //        gameId = value;
        //        NotifyPropertyChanged();
        //    }
        //}

        //public byte[] Content
        //{
        //    get { return content; }
        //    set
        //    {
        //        content = value;
        //        NotifyPropertyChanged();
        //    }
        //}

        //#endregion

        //#region Notify property changed implementation

        ///// <summary>
        ///// Property changed event handler
        ///// </summary>
        //public event PropertyChangedEventHandler PropertyChanged;

        //// Notify that property is changed, called by set accessors
        //public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        //{
        //    if (PropertyChanged != null)
        //        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        //}

        //#endregion
    }
}
