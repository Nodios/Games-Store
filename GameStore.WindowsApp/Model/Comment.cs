using GalaSoft.MvvmLight;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GameStore.WindowsApp.Model 
{
    public class Comment : ObservableObject
    {

        public Guid Id { get; set; }
        public Guid PostId { get; set; }
        public string UserId { get; set; }

        public string Description { get; set; }
        public string UserName { get; set; }
        public DateTime Date { get; set; }

        //#region Fields

        //private Guid id;
        //private Guid postId;
        //private string userId;
        //private string description;
        //private string userName;
        //private DateTime date; 

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

        //public Guid PostId
        //{
        //    get { return postId; }
        //    set
        //    {
        //        postId = value;
        //        NotifyPropertyChanged();
        //    }
        //}

        //public string UserId
        //{
        //    get { return userId; }
        //    set
        //    {
        //        userId = value;
        //        NotifyPropertyChanged();
        //    }
        //}

        //public string Description
        //{
        //    get { return description; }
        //    set
        //    {
        //        description = value;
        //        NotifyPropertyChanged();
        //    }
        //}

        //public string UserName
        //{
        //    get { return userName; }
        //    set
        //    {
        //        userName = value;
        //        NotifyPropertyChanged();
        //    }
        //}

        //public DateTime Date
        //{
        //    get { return date; }
        //    set
        //    {
        //        date = value;
        //        NotifyPropertyChanged();
        //    } 

        //#endregion
        //}

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
