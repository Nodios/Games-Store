using GalaSoft.MvvmLight;
using System;

namespace GameStore.WindowsApp.Model
{
    public class Post : ObservableObject
    {
        public Guid Id { get; set; }
        public Guid TopicId { get; set; }
        public Guid UserId { get; set; }

        public int VotesUp { get; set; }
        public int VotesDown { get; set; }
        public string Description { get; set; }
        public string UserName { get; set; }
        public DateTime Date { get; set; }

        //#region Fields

        //private Guid id;
        //private Guid topicId;
        //private Guid userId;
        //private string description;
        //private DateTime date;
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

        //public Guid TopicId
        //{
        //    get { return topicId; }
        //    set
        //    {
        //        topicId = value;
        //        NotifyPropertyChanged();
        //    }
        //}

        //public Guid UserId
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

        //public DateTime Date
        //{
        //    get { return date; }
        //    set
        //    {
        //        date = value;
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
