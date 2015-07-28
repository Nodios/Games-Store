﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using GameStore.WindowsApp.Model;
using GameStore.WindowsApp.Service.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace GameStore.WindowsApp.ViewModel
{
    public enum GameSearchType { ByName, EmptySearch };

    public class GamesViewModel : ViewModelBase
    {
        #region Fields

        // Local fields, without proprites
        private int pageNumber = 1;
        private const int MAX_NUMBER_OF_ITEMS_ON_PAGE = 5;
        private GameSearchType searchType = GameSearchType.EmptySearch;

        // Fields for one way binding proporties
        private readonly string title;

        // Fields for two way binding proporties
        private string searchString = "";
        private bool gameDetailsVisible;
        private bool goForwardButtonVisible;
        private bool previousButtonVisible;
        private bool showUserSubMenu;
        private bool showUserLogged;
        private Game game;
        private GameImage gameImage;
        private ObservableCollection<Game> gamesCollection;
        private User user;

        // Services
        private readonly INavigationService navigation;
        private readonly IGamesService gamesService;
        private readonly IGameImageService gameImageService;
        private readonly ICartService cartService;

        // Commands
        private RelayCommand<Guid> getGameCommand;
        private RelayCommand mainpageCommand;
        private RelayCommand getGamesCommand;
        private RelayCommand goBack;
        private RelayCommand backInList;
        private RelayCommand forwardInList;
        private RelayCommand showUserOptionsMenuCommand;
        private RelayCommand closeUserOptionsCommand;
        private RelayCommand logoutCommand;
        private RelayCommand addToCartCommand;



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
        /// Used to set visibility of previous button
        /// </summary>
        public bool PreviousButtonVisible
        {
            get { return previousButtonVisible; }
            set { Set(() => this.PreviousButtonVisible, ref previousButtonVisible, value); }
        }

        /// <summary>
        /// Used to set visibilte of search for more button
        /// </summary>
        public bool GoForwardButtonVisible
        {
            get { return goForwardButtonVisible; }
            set { Set(() => this.GoForwardButtonVisible, ref goForwardButtonVisible, value); }
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

        /// <summary>
        /// Shows logged in menu if user is logged in
        /// </summary>
        public bool ShowUserLogged
        {
            get { return showUserLogged; }
            set { Set(() => this.ShowUserLogged, ref showUserLogged, value); }
        }

        /// <summary>
        /// User submenu, with cart, order navigation proporties
        /// </summary>
        public bool ShowUserSubMenu
        {
            get { return showUserSubMenu; }
            set { Set(() => this.ShowUserSubMenu, ref showUserSubMenu, value); }
        }

        /// <summary>
        /// User
        /// </summary>
        public User User
        {
            get
            {

                if (!String.IsNullOrEmpty(GameStore.WindowsApp.Common.UserInfo.Username))
                {
                    user = new User()
                    {
                        Id = GameStore.WindowsApp.Common.UserInfo.Id,
                        Access_token = GameStore.WindowsApp.Common.UserInfo.Token,
                        UserName = GameStore.WindowsApp.Common.UserInfo.Username
                    };
                }

                return user;
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes new instance of GamesViewModel
        /// </summary>
        public GamesViewModel(INavigationService navigation, IGamesService gamesService, IGameImageService gameImageService, ICartService cartService)
        {
            this.navigation = navigation;
            this.gamesService = gamesService;
            this.gameImageService = gameImageService;
            this.cartService = cartService;

            gamesCollection = new ObservableCollection<Game>();

            title = "Find games";
            GameDetailsVisible = false;
            PreviousButtonVisible = false;
            GoForwardButtonVisible = false;

            if (!String.IsNullOrEmpty(GameStore.WindowsApp.Common.UserInfo.Username))
                ShowUserLogged = true;

            // Notify when user name is changed
            GameStore.WindowsApp.Common.UserInfo.OnUserNameChange += () =>
            {
                if (String.IsNullOrEmpty(GameStore.WindowsApp.Common.UserInfo.Username))
                    ShowUserLogged = false;
                else
                    ShowUserLogged = true;
            };
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
                return goBack ?? (goBack = new RelayCommand(() =>
                    {
                        pageNumber = 1;
                        searchString = "";
                        navigation.GoBack();
                    }));
            }
        }

        /// <summary>
        /// Redirects user to main page
        /// </summary>
        public RelayCommand MainpageCommand
        {
            get
            {
                return mainpageCommand ?? (mainpageCommand = new RelayCommand(() => navigation.NavigateTo(ViewModelLocator.MAIN_PAGE_KEY)));
            }
        }

        /// <summary>
        /// Click on go back in list
        /// </summary>
        public RelayCommand BackInList
        {
            get
            {
                return backInList ?? (backInList =
                    new RelayCommand(() =>
                        {
                            pageNumber--;

                            if (pageNumber < 1)
                                pageNumber = 1;

                            getGames();
                            sizeAndPageNumberChecks();
                        }));
            }
        }

        /// <summary>
        /// Click on go forward in list
        /// </summary>
        public RelayCommand ForwardInList
        {
            get
            {
                return forwardInList ?? (forwardInList =
                    new RelayCommand(() =>
                        {
                            pageNumber++;
                            getGames();
                            sizeAndPageNumberChecks();
                        }));
            }
        }

        /// <summary>
        /// Show user options
        /// </summary>
        public RelayCommand ShowUserOptionsMenuCommand
        {
            get { return showUserOptionsMenuCommand ?? (showUserOptionsMenuCommand = new RelayCommand(() => ShowUserSubMenu = true)); }
        }

        /// <summary>
        /// Hide user options
        /// </summary>
        public RelayCommand CloseUserOptionsCommand
        {
            get { return closeUserOptionsCommand ?? (closeUserOptionsCommand = new RelayCommand(() => ShowUserSubMenu = false)); }
        }

        public RelayCommand LogoutCommand
        {
            get
            {
                return logoutCommand ?? (logoutCommand = new RelayCommand(() =>
                {
                    ShowUserSubMenu = false;
                    GameStore.WindowsApp.Common.UserInfo.Id = "";
                    GameStore.WindowsApp.Common.UserInfo.Token = "";
                    GameStore.WindowsApp.Common.UserInfo.Username = "";
                }));
            }
        }

        /// <summary>
        /// Adds game to cart
        /// </summary>
        public RelayCommand AddToCartCommand
        {
            get
            {
                return addToCartCommand ?? (addToCartCommand = new RelayCommand(async () =>
                    {
                        MessageDialog messagedialog = null;

                        try
                        {
                            int result = await addToCart();
                            string msg;
                            if (result >= 1)
                                msg = "Added to cart.";
                            else
                                msg = "Please login and try again.";

                            messagedialog = new MessageDialog(msg);
                        }
                        catch (Exception ex)
                        {
                            messagedialog = new MessageDialog(ex.Message);
                        }

                        await messagedialog.ShowAsync();
                    }));
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
                    // Check if previous search way by name and sets page number and search type 
                    if (searchType == GameSearchType.ByName)
                    {
                        pageNumber = 1;
                        searchType = GameSearchType.EmptySearch;
                    }


                    IEnumerable<Game> games = await gamesService.GetRangeAsync(
                        new Utilities.GenericFilter(pageNumber, MAX_NUMBER_OF_ITEMS_ON_PAGE));

                    // Game should be set to null, before clearing game list , since it's selected item in games list
                    Game = null;
                    gamesCollection.Clear();
                    foreach (Game game in games)
                        gamesCollection.Add(game);
                }
                else
                {
                    // Checks if previous search way empty search and sets page number and search type
                    if (searchType == GameSearchType.EmptySearch)
                    {
                        pageNumber = 1;
                        searchType = GameSearchType.ByName;
                    }

                    IEnumerable<Game> games = await gamesService.GetRangeAsync(searchString,
                        new Utilities.GenericFilter(pageNumber, MAX_NUMBER_OF_ITEMS_ON_PAGE));

                    // Game should be set to null, before clearing game list , since it's selected item in games list
                    Game = null;
                    gamesCollection.Clear();
                    foreach (Game game in games)
                        gamesCollection.Add(game);
                }

                sizeAndPageNumberChecks();
            }

            catch (Exception ex)
            {
                // TODO implement string so that UI can have alert box with exception
                throw ex;
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
                    GameDetailsVisible = false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private async Task<int> addToCart()
        {
            try
            {
                Cart cart = new Cart(GameStore.WindowsApp.Common.UserInfo.Id);
                cart.GamesInCart.Add(game);

                int result = await cartService.UpdateAsync(cart);



                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void sizeAndPageNumberChecks()
        {
            // GO FORWARD CHECKS
            if (gamesCollection.Count >= MAX_NUMBER_OF_ITEMS_ON_PAGE)
                GoForwardButtonVisible = true;
            else
                GoForwardButtonVisible = false;

            // GO BACK CHECKS
            if (pageNumber > 1)
                PreviousButtonVisible = true;
            else
                PreviousButtonVisible = false;

        }

        #endregion
    }
}
