using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using GameStore.WindowsApp.Model;
using GameStore.WindowsApp.Service.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.WindowsApp.ViewModel
{
    public class GamesViewModel : ViewModelBase
    {
        #region Fields

        private readonly string title;

        private string searchString;
        private ObservableCollection<Game> gamesCollection;

        private INavigationService navigation;
        private IGamesService gamesService;

        private RelayCommand getGamesCommand;

        #endregion

        #region Proporties

        public string Title
        {
            get { return title; }
        }

        public string SearchString
        {
            get { return searchString; }
            set { Set(() => this.SearchString, ref searchString, value); }
        }

        public ObservableCollection<Game> GamesCollection
        {
            get { return gamesCollection; }
            set { Set(() => this.GamesCollection, ref gamesCollection, value); }
        }

        #endregion

        #region Constructor

        public GamesViewModel(INavigationService navigation, IGamesService gamesService)
        {
            this.navigation = navigation;
            this.gamesService = gamesService;

            gamesCollection = new ObservableCollection<Game>();

            title = "Search for games";
        }

        #endregion

        #region Commands

        public RelayCommand GetGames
        {
            get
            {
                return getGamesCommand ?? (getGamesCommand = new RelayCommand(getGames));
            }
        }

        #endregion

        #region Methods

        private async void getGames()
        {
            try
            {
                if (String.IsNullOrEmpty(searchString))
                {
                    IEnumerable<Game> games = await gamesService.GetRangeAsync(new Utilities.GenericFilter(1, 6));
                    string s = games.ToString();
                    gamesCollection.Clear();
                    foreach (Game game in games)
                        gamesCollection.Add(game);
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                // TODO implement string so that UI can have alert box with exception
                throw;
            }
        }

        #endregion
    }
}
