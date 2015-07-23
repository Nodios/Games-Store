using GalaSoft.MvvmLight;
using System;

namespace GameStore.WindowsApp.Model
{
    public class Review : ObservableObject
    {
        public Guid Id { get; set; }
        public Guid GameId { get; set; }
        public string UserId { get; set; }

        public string Author { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public float Score { get; set; }

        public User User { get; set; }

        //#region Fields

        //private Guid id;
        //private Guid gameId;
        //private string userId;
        //private string author;
        //private string description;
        //private string title;
        //private float score;
        //private User user; 

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

        //public string UserId
        //{
        //    get { return userId; }
        //    set
        //    {
        //        userId = value;
        //        NotifyPropertyChanged();
        //    }
        //}

        //public string Author
        //{
        //    get { return author; }
        //    set
        //    {
        //        author = value;
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

        //public string Title
        //{
        //    get { return title; }
        //    set
        //    {
        //        title = value;
        //        NotifyPropertyChanged();
        //    }
        //}

        //public float Score
        //{
        //    get { return score; }
        //    set
        //    {
        //        score = value;
        //        NotifyPropertyChanged();
        //    }
        //}

        //public User User
        //{
        //    get { return user; }
        //    set
        //    {
        //        user = value;
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
