using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using GameStore.WindowsApp.Model;
using GameStore.WindowsApp.Service.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GameStore.WindowsApp.ViewModel
{
    public class GamesViewModel : ViewModelBase
    {
        #region Fields

        // Fields for one way binding proporties
        private readonly string title;

        // Fields for two way binding proporties
        private string searchString = "";
        private bool gameDetailsVisible;
        private Game game;
        private GameImage gameImage;
        private ObservableCollection<Game> gamesCollection;

        // Services
        private readonly INavigationService navigation;
        private readonly IGamesService gamesService;
        private readonly IGameImageService gameImageService;

        // Commands
        private RelayCommand<Guid> getGameCommand;
        private RelayCommand getGamesCommand;
        private RelayCommand goBack;

        #endregion

        #region Proporties

        /// <summary>
        /// Gets title for page
        /// </summary>
        public string Title
        {
            get { return title; }
        }

        /// <summary>
        /// Search string for filtering games
        /// </summary>
        public string SearchString
        {
            get { return searchString; }
            set { Set(() => this.SearchString, ref searchString, value); }
        }

        /// <summary>
        /// Used to set visiblity of UI game details part 
        /// </summary>
        public bool GameDetailsVisible
        {
            get { return gameDetailsVisible; }
            set { Set(() => this.GameDetailsVisible, ref gameDetailsVisible, value); }
        }

        /// <summary>
        /// Observable game
        /// </summary>
        public Game Game
        {
            get { return game; }
            set { Set(() => this.Game, ref game, value); }
        }

        /// <summary>
        /// Two way game image
        /// </summary>
        public GameImage GameImage
        {
            get { return gameImage; }
            set { Set(() => this.GameImage, ref gameImage, value); }
        }

        /// <summary>
        /// Observable collection of games
        /// </summary>
        public ObservableCollection<Game> GamesCollection
        {
            get { return gamesCollection; }
            set { Set(() => this.GamesCollection, ref gamesCollection, value); }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes new instance of GamesViewModel
        /// </summary>
        public GamesViewModel(INavigationService navigation, IGamesService gamesService, IGameImageService gameImageService)
        {
            this.navigation = navigation;
            this.gamesService = gamesService;
            this.gameImageService = gameImageService;

            gamesCollection = new ObservableCollection<Game>();

            title = "Find games";
            gameDetailsVisible = false;
        }

        #endregion

        #region Commands

        /// <summary>
        /// Get game by id
        /// </summary>
        public RelayCommand<Guid> GetGame
        {
            get
            {
                return getGameCommand ?? (getGameCommand = new RelayCommand<Guid>((g) => getGame(g)));
            }
        }

        /// <summary>
        /// Command that invokes getGames() method
        /// </summary>
        public RelayCommand GetGames
        {
            get
            {
                return getGamesCommand ?? (getGamesCommand = new RelayCommand(getGames));
            }
        }

        /// <summary>
        /// Goes back to main menu
        /// </summary>
        public RelayCommand GoBack
        {
            get
            {
                return goBack = new RelayCommand(navigation.GoBack);
            }
        }

        #endregion

        #region Public methods
        
        #endregion

        #region Private Methods

        /// <summary>
        /// Fills game collection based on various search options
        /// </summary>
        private async void getGames()
        {
            try
            {
                if (String.IsNullOrEmpty(searchString))
                {
                    IEnumerable<Game> games = await gamesService.GetRangeAsync(new Utilities.GenericFilter(1, 5));

                    // Game should be set to null, before clearing game list , since it's selected item in games list
                    Game = null;
                    gamesCollection.Clear();
                    foreach (Game game in games)
                        gamesCollection.Add(game);
                }
                else
                {
                    IEnumerable<Game> games = await gamesService.GetRangeAsync(searchString, new Utilities.GenericFilter(1, 5));

                    // Game should be set to null, before clearing game list , since it's selected item in games list
                    Game = null;
                    gamesCollection.Clear();
                    foreach (Game game in games)
                        gamesCollection.Add(game);
                }
            }
            
            catch (Exception ex)
            {
                // TODO implement string so that UI can have alert box with exception
                throw;
            }
        }

        /// <summary>
        /// Gets game by id 
        /// </summary>
        /// <param name="id">Id</param>
        private async void getGame(Guid id)
        {
            try
            {
                Game result = await gamesService.GetAsync(id);
                GameImage imageResult = await gameImageService.GetAsync(id);

                Game = result;
                GameImage = imageResult;

                if (Game != null)
                    GameDetailsVisible = true;
                else
                    gameDetailsVisible = false;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        #endregion
    }
}
