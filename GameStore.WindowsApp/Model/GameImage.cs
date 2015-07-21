using GalaSoft.MvvmLight;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GameStore.WindowsApp.Model
{
    public class GameImage : ObservableObject
    {
        #region Fields

        private Guid id;
        private Guid gameId;
        private byte[] content;

        #endregion

        #region Proporties

        public Guid Id
        {
            get { return id; }
            set { id = value; }
        }

        public Guid GameId
        {
            get { return gameId; }
            set { gameId = value; }
        }

        public byte[] Content
        {
            get { return content; }
            set
            {
                content = value;
                Set(() => this.Content, ref content, value);
            }
        }

        #endregion
    }
}
