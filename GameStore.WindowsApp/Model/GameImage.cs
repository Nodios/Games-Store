using GalaSoft.MvvmLight;
using System;

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

        /// <summary>
        /// Implements notify property changed
        /// </summary>
        public byte[] Content
        {
            get { return content; }
            set { Set(() => this.Content, ref content, value); }
        }

        #endregion
    }
}
