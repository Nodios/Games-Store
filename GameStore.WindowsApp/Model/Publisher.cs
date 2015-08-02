using GalaSoft.MvvmLight;
using System;

namespace GameStore.WindowsApp.Model
{
    public class Publisher : ObservableObject
    {
        #region Fields

        private Guid id;
        private string name;
        private string description;
        private Support support;

        #endregion

        #region Proporties

        public Guid Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public Support Support
        {
            get { return support; }
            set { Set(() => this.Support, ref support, value); }
        }

        #endregion

    }
}
