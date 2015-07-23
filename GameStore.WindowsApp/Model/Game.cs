﻿using GalaSoft.MvvmLight;
using System;

namespace GameStore.WindowsApp.Model
{
    public class Game : ObservableObject
    {
        #region Fields

        private Guid id;
        private Guid publisherId;
        private string name;
        private string description;
        private string osSupport;
        private float? reviewScore;
        private string genre;
        private double price;
        private bool isInCart;
        private GameImage gameImage;

        #endregion


        #region Proporties

        public Guid Id
        {
            get { return id; }
            set { id = value; }
        }

        public Guid PublisherId
        {
            get { return publisherId; }
            set { publisherId = value; }
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

        public string OsSupport
        {
            get { return osSupport; }
            set { osSupport = value; }
        }

        public float? ReviewScore
        {
            get { return reviewScore; }
            set { reviewScore = value; }
        }

        public string Genre
        {
            get { return genre; }
            set { genre = value; }
        }

        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        /// <summary>
        /// Implements notify property changed
        /// </summary>
        public bool IsInCart
        {
            get { return isInCart; }
            set { Set(() => this.IsInCart, ref isInCart, value); }
        }

        /// <summary>
        /// Implements notify property changed
        /// </summary>
        public GameImage GameImage
        {
            get { return gameImage; }
            set { Set(() => this.GameImage, ref gameImage, value); }
        }

        #endregion
       
    }
}
