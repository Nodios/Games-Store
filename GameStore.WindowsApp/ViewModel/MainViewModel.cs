using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using GameStore.WindowsApp.Model;
using GameStore.WindowsApp.Service.Common;
using System;
using System.Threading.Tasks;
using Windows.Storage;

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

     

        private string userName;
        private string password;
        private User user;
        private bool registerAndLoginButtonVisibility;
        private bool userLoggedInButtonVisibility;
        public bool loginFormVisibility;

        private readonly INavigationService navigationService;
        private readonly IUserService userService;

        private RelayCommand navigateToGamesPageCommand;
        private RelayCommand loginCommand;
        private RelayCommand showLoginFormCommand;

        ApplicationDataContainer settings = ApplicationData.Current.LocalSettings;

        #endregion

        #region Proporties

        /// <summary>
        /// Gets title for view model
        /// </summary>
        public string Title
        {
            get { return title; }
        }

        /// <summary>
        /// Two way
        /// </summary>
        public bool RegisterAndLoginButtonVisibility
        {
            get { return registerAndLoginButtonVisibility; }
            set { Set(() => this.RegisterAndLoginButtonVisibility, ref registerAndLoginButtonVisibility, value); }
        }

        /// <summary>
        /// Two way
        /// </summary>
        public bool UserLoggedinButtonVisibility
        {
            get { return userLoggedInButtonVisibility; }
            set { Set(() => this.UserLoggedinButtonVisibility, ref userLoggedInButtonVisibility, value); }
        }

        /// <summary>
        /// Gets and sets visibilty of login form
        /// </summary>
        public bool LoginFormVisibility
        {
            get { return loginFormVisibility; }
            set { Set(() => this.LoginFormVisibility, ref loginFormVisibility, value); }
        }

        /// <summary>
        /// Gets and sets username, two way binding
        /// </summary>
        public string UserName
        {
            get { return userName; }
            set { Set(() => this.UserName, ref userName, value); }
        }

        /// <summary>
        /// Gets and sets password, two way binding
        /// </summary>
        public string Password
        {
            get { return password; }
            set { Set(() => this.Password, ref password, value); }
        }

        /// <summary>
        /// Gets and sets user, two way binding
        /// </summary>
        public User User
        {
            get { return user; }
            set { Set(() => this.User, ref user, value); }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(INavigationService navigationService, IUserService userService)
        {
            title = "Games Store";

            this.navigationService = navigationService;
            this.userService = userService;

            registerAndLoginButtonVisibility = true;
            userLoggedInButtonVisibility = false;
            loginFormVisibility = false;
        }

        #endregion

        #region Commands


        public RelayCommand ShowLoginFormCommand
        {
            get
            {
                return showLoginFormCommand
                    ?? (showLoginFormCommand = new RelayCommand(
                        () =>
                        {
                            LoginFormVisibility = true;
                        }));
            }
        }

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
   
        /// <summary>
        /// Login command
        /// </summary>
        public RelayCommand LoginCommand
        {
            get
            {
                return loginCommand ?? (loginCommand = new RelayCommand(async() => User = await login()));                
            }
        }

        #endregion

        #region Public methods

        public void Load(DateTime lastVisit)
        {

        }


        #endregion

        #region Private methods

        /// <summary>
        /// User login
        /// </summary>
        private async Task<User> login()
        {
            try
            {
               User result = await userService.FindAsync(userName, password);
               UserName = GameStore.WindowsApp.Common.UserInfo.Username;     


               if (!String.IsNullOrEmpty(userName))
               {
                   RegisterAndLoginButtonVisibility = false;
                   UserLoggedinButtonVisibility = true;
                   LoginFormVisibility = false;                
               }

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