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
        /// <summary>
        /// The <see cref="WelcomeTitle" /> property's name.
        /// </summary>
        public const string WelcomeTitlePropertyName = "WelcomeTitle";

        private readonly IDataService _dataService;
        private readonly INavigationService _navigationService;

        private readonly IGamesService gamesService;

        private RelayCommand _navigateCommand;
        private RelayCommand getGame;
        private string _originalTitle;
        private string _welcomeTitle = string.Empty;
        private Game game;

        /// <summary>
        /// Gets the NavigateCommand.
        /// </summary>
        public RelayCommand NavigateCommand
        {
            get
            {
                return _navigateCommand
                       ?? (_navigateCommand = new RelayCommand(
                           () => _navigationService.NavigateTo(ViewModelLocator.GamesPageKey)));


            }
        }

        public RelayCommand GetGame
        {
            get
            {
                return getGame ?? (getGame = new RelayCommand(Get));
            }
        }
        /// <summary>
        /// Gets the WelcomeTitle property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string WelcomeTitle
        {
            get
            {
                return _welcomeTitle;
            }

            set
            {
                Set(ref _welcomeTitle, value);
            }
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(
            IDataService dataService,
            INavigationService navigationService, IGamesService gamesService)
        {
            _dataService = dataService;
            _navigationService = navigationService;

            // For testing
            this.gamesService = gamesService;

            Initialize();
        }

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
        public void Load(DateTime lastVisit)
        {
            if (lastVisit > DateTime.MinValue)
            {
                WelcomeTitle = string.Format(
                    "{0} (last visit on the {1})",
                    _originalTitle,
                    lastVisit);
            }
        }

        private async Task Initialize()
        {
            try
            {
                var item = await _dataService.GetData();
                _originalTitle = item.Title;
                WelcomeTitle = item.Title;
            }
            catch (Exception ex)
            {
                // Report error here
            }
        }

        private async void Get()
        {
            try
            {
                var v = await gamesService.GetAsync(Guid.Parse("02a4269e-702d-e511-89a8-689423c58a9c"));
                Game = v;
            }
            catch (Exception ex)
            {
                MessageDialog msg = new MessageDialog(ex.Message);
            }
        }

        public Game Game
        {
            get { return game; }
            set
            {
                Set(() => this.Game, ref game, value);
            }
        }
    }
}