
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using GameStore.WindowsApp.Model;
using GameStore.WindowsApp.Service.Common;
using System;

namespace GameStore.WindowsApp.ViewModel
{
    public class CartViewModel : ViewModelBase
    {
        #region Fields

        private readonly INavigationService navigationService;
        private readonly ICartService cartService;

        private Cart cart;

        private RelayCommand loadedCommand;

        #endregion

        #region Proporties

        /// <summary>
        /// Get and set cart
        /// </summary>
        public Cart Cart
        {
            get { return cart; }
            set { Set(() => this.Cart, ref cart, value); }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public CartViewModel(INavigationService navigationService, ICartService cartService)
        {
            this.navigationService = navigationService;
            this.cartService = cartService;
        }

        #endregion

        #region Commands

        public RelayCommand LoadedCommand
        {
            get
            {
                return loadedCommand ?? (loadedCommand = new RelayCommand(async () =>
                {
                    try
                    {
                        Cart = await cartService.GetAsync(GameStore.WindowsApp.Common.UserInfo.Id);
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                }));
            }
        }
        #endregion

    }
}
