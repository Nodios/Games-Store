
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using GameStore.WindowsApp.Model;
using GameStore.WindowsApp.Service.Common;
using System;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace GameStore.WindowsApp.ViewModel
{
    public class CartViewModel : ViewModelBase
    {
        #region Fields

        private readonly INavigationService navigationService;
        private readonly ICartService cartService;
        private readonly IGamesService gameService;
        private readonly IOrderService orderService;

        private Cart cart;
        private string price;
        private bool showIfThereAreGames;
        private Game selectedGame;
        private bool showOrderForm;
        private Order order;

        private RelayCommand loadedCommand;
        private RelayCommand<Guid> deleteGameCommand;
        private RelayCommand gamesPageCommand;
        private RelayCommand showOrderFormCommand;
        private RelayCommand hideOrderFormCommand;
        private RelayCommand orderCommand;

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

        /// <summary>
        /// Get and sets total price of games
        /// </summary>
        public string Price
        {
            get { return price; }
            set { Set(() => this.Price, ref price, value); }
        }

        /// <summary>
        /// Hides or shows appropriate menus
        /// </summary>
        public bool ShowIfThereAreGames
        {
            get { return showIfThereAreGames; }
            set { Set(() => this.ShowIfThereAreGames, ref showIfThereAreGames, value); }
        }

        /// <summary>
        /// Gets and sets selected game id
        /// </summary>
        public Game SelectedGame
        {
            get { return selectedGame; }
            set { Set(() => this.SelectedGame, ref selectedGame, value); }
        }

        /// <summary>
        /// Gets and sets visibility of show order form
        /// </summary>
        public bool ShowOrderForm
        {
            get { return showOrderForm; }
            set { Set(() => this.ShowOrderForm, ref showOrderForm, value); }
        }

        /// <summary>
        /// Gets and sets order
        /// </summary>
        public Order Order
        {
            get { return order; }
            set { Set(() => this.Order, ref order, value); }
        }
        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public CartViewModel(INavigationService navigationService, ICartService cartService, IGamesService gameService,
            IOrderService orderService)
        {
            this.navigationService = navigationService;
            this.cartService = cartService;
            this.gameService = gameService;
            this.orderService = orderService;

            Order = new Order();
        }

        #endregion

        #region Commands

        /// <summary>
        /// On load
        /// </summary>
        public RelayCommand LoadedCommand
        {
            get
            {
                return loadedCommand ?? (loadedCommand = new RelayCommand(async () =>
                {
                    try
                    {
                        Cart = await cartService.GetAsync(GameStore.WindowsApp.Common.UserInfo.Id);

                        // Hide menus and break out if there are no games
                        if (Cart.GamesInCart.Count == 0)
                        {
                            ShowIfThereAreGames = false;
                            return;
                        }
                        else
                            ShowIfThereAreGames = true;

                        double p = 0;
                        foreach (Game g in Cart.GamesInCart)
                            p += g.Price;

                        Price = p.ToString();
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                }));
            }
        }

        /// <summary>
        /// Deletes games
        /// </summary>
        public RelayCommand<Guid> DeleteGameCommand
        {
            get
            {
                return deleteGameCommand ?? (deleteGameCommand = new RelayCommand<Guid>(async (id) =>
                {
                    MessageDialog msg;

                    try
                    {
                        bool result = await deleteGame(id);

                        // If there is game show message and execute get games command
                        if (result)
                        {
                            msg = new MessageDialog("Game deleted");
                            LoadedCommand.Execute(null);
                        }
                        else
                            msg = new MessageDialog("Error while trying to delete game.");

                    }
                    catch (Exception ex)
                    {
                        msg = new MessageDialog(ex.Message);
                        msg.Commands.Add(new UICommand("Cancel"));
                    }
                    await msg.ShowAsync();
                }));
            }
        }

        /// <summary>
        /// Goes to games page
        /// </summary>
        public RelayCommand GamesPageCommand
        {
            get
            {
                return gamesPageCommand ?? (gamesPageCommand =
                    new RelayCommand(() => this.navigationService.NavigateTo(ViewModelLocator.GAMES_PAGE_KEY)));
            }
        }

        /// <summary>
        /// Shows order form
        /// </summary>
        public RelayCommand ShowOrderFormCommand
        {
            get
            {
                return showOrderFormCommand ?? (showOrderFormCommand = new RelayCommand(delegate() { ShowOrderForm = true; }));
            }
        }

        /// <summary>
        /// Hides order form
        /// </summary>
        public RelayCommand HideOrderFormCommand
        {
            get
            {
                return hideOrderFormCommand ?? (hideOrderFormCommand = new RelayCommand(delegate() { ShowOrderForm = false; }));
            }
        }

        public RelayCommand OrderCommand
        {
            get
            {
                return orderCommand ?? (orderCommand = new RelayCommand(async delegate()
                {
                    MessageDialog msg;
                    try
                    {
                        double amount = 0;
                        Double.TryParse(Price, out amount);
                        Order.Amount = amount;
                        Order.UserId = GameStore.WindowsApp.Common.UserInfo.Id;
                        Order result = await orderService.AddAsync(Order);

                        if (result != null)
                            msg = new MessageDialog("Order placed.");
                        else
                            msg = new MessageDialog("Error while proccessing order.");

                    }
                    catch (Exception ex)
                    {
                        msg = new MessageDialog(ex.Message);
                        msg.Commands.Add(new UICommand("OK"));
                    }
                    await msg.ShowAsync();
                }));
            }
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Deletes game
        /// </summary>
        /// <param name="gameId">Game id</param>
        /// <returns></returns>
        private async Task<bool> deleteGame(Guid gameId)
        {
            try
            {
                bool result = await gameService.DeleteAsync(gameId);

                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion
    }
}
