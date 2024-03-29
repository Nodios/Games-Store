﻿using GalaSoft.MvvmLight;
using System;

namespace GameStore.WindowsApp.Model
{
    public class Topic : ObservableObject
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string UserName { get; set; }

        //#region Fields

        //private Guid id;
        //private string userId;
        //private string title;
        //private string userName; 

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

        //public string UserId
        //{
        //    get { return userId; }
        //    set
        //    {
        //        userId = value;
        //        NotifyPropertyChanged();
        //    }
        //}

        //public string Title
        //{
        //    get { return title; }
        //    set
        //    {
        //        title = value;
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
