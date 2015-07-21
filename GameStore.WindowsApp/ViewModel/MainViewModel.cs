using System;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using GameStore.WindowsApp.Model;
using GameStore.WindowsApp.Service.Common;
using System.ServiceModel.Channels;
using Windows.UI.Popups;

namespace GameStore.WindowsApp.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        #region Fields

        private readonly string title;

        private readonly INavigationService navigationService;

        private RelayCommand navigateToGamesPageCommand; 

        #endregion

        #region Proporties

        /// <summary>
        /// Gets title for view model
        /// </summary>
        public string Title
        {
            get { return title; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(INavigationService navigationService)
        {
            title = "Games Store";

            this.navigationService = navigationService;
        } 

        #endregion

        #region Commands

        /// <summary>
        /// Navigates to Games page
        /// </summary>
        public RelayCommand NavigateToGamesPageCommand
        {
            get
            {
                return navigateToGamesPageCommand
                       ?? (navigateToGamesPageCommand = new RelayCommand(
                           () => navigationService.NavigateTo(ViewModelLocator.GamesPageKey)));


            }
        }

        #endregion

        #region Public methods

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}

        public void Load(DateTime lastVisit)
        {

        } 

        #endregion

        #region Private methods



        #endregion
    }
}