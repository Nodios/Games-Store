using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;

using GameStore.WindowsApp.Model;
using GameStore.WindowsApp.Service.Common;
using System;
using System.Threading.Tasks;
using Windows.Storage;
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

        private string loginUserName;
        private string loginPassword;
        private string checkRegisterFormPassword;
        private User user;
        private User userToRegister;
        private bool registerAndLoginButtonVisibility;
        private bool userLoggedInButtonVisibility;
        private bool loginFormVisibility;
        private bool registerFormVisibility;
        private bool showUserSubMenu;

        private readonly INavigationService navigationService;
        private readonly IUserService userService;

        private RelayCommand navigateToGamesPageCommand;
        private RelayCommand navigateToPublisherPageCommand;
        private RelayCommand loginCommand;
        private RelayCommand registerCommand;
        private RelayCommand showLoginFormCommand;
        private RelayCommand showRegisterFormCommand;
        private RelayCommand showUserMenuOptionCommand;
        private RelayCommand closeUserOptionCommand;
        private RelayCommand logoutCommand;

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
        /// Gets and sets register form visibility
        /// </summary>
        public bool RegisterFormVisibility
        {
            get { return registerFormVisibility; }
            set { Set(() => this.RegisterFormVisibility, ref registerFormVisibility, value); }
        }

        /// <summary>
        /// gets and sets user menu options, with cart, orders ....
        /// </summary>
        public bool ShowUserSubMenu
        {
            get { return showUserSubMenu; }
            set { Set(() => this.ShowUserSubMenu, ref showUserSubMenu, value); }
        }

        /// <summary>
        /// Gets and sets username, two way binding
        /// </summary>
        public string LoginUserName
        {
            get { return loginUserName; }
            set { Set(() => this.LoginUserName, ref loginUserName, value); }
        }

        /// <summary>
        /// Gets and sets password, two way binding
        /// </summary>
        public string LoginPassword
        {
            get { return loginPassword; }
            set { Set(() => this.LoginPassword, ref loginPassword, value); }
        }

        /// <summary>
        /// Password user for register form password check
        /// </summary>
        public string CheckRegisterFormPassword
        {
            get { return checkRegisterFormPassword; }
            set { Set(() => this.CheckRegisterFormPassword, ref checkRegisterFormPassword, value); }

        }

        /// <summary>
        /// Gets and sets user, two way binding
        /// </summary>
        public User User
        {
            get { return user; }
            set { Set(() => this.User, ref user, value); }
        }

        /// <summary>
        /// Gets and sets user to register
        /// </summary>
        public User UserToRegister
        {
            get { return userToRegister; }
            set { Set(() => this.UserToRegister, ref userToRegister, value); }
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
            showUserSubMenu = false;

            this.LoginUserName = GameStore.WindowsApp.Common.UserInfo.Username;

            // if user to register is null , create new one
            userToRegister = userToRegister ?? (userToRegister = new User() { });
        }

        #endregion

        #region Commands

        /// <summary>
        /// Shows login form
        /// </summary>
        public RelayCommand ShowLoginFormCommand
        {
            get
            {
                return showLoginFormCommand
                    ?? (showLoginFormCommand = new RelayCommand(
                        () =>
                        {
                            RegisterFormVisibility = false;
                            LoginFormVisibility = true;
                            ShowUserSubMenu = false;
                        }));
            }
        }

        /// <summary>
        /// Shows register form
        /// </summary>
        public RelayCommand ShowRegisterFormCommand
        {
            get
            {
                if (showRegisterFormCommand != null)
                    return showRegisterFormCommand;
                else
                    return showRegisterFormCommand = new RelayCommand(() =>
                        {
                            LoginFormVisibility = false;
                            RegisterFormVisibility = true;
                            ShowUserSubMenu = false;
                        });
            }
        }

        /// <summary>
        /// Shows user options menu
        /// </summary>
        public RelayCommand ShowUserOptionsMenuCommand
        {
            get
            {
                return showUserMenuOptionCommand ?? (showUserMenuOptionCommand = new RelayCommand(() =>
                {
                    LoginFormVisibility = false;
                    RegisterFormVisibility = false;
                    ShowUserSubMenu = true;
                }));
            }
        }

        /// <summary>
        /// Close pop up
        /// </summary>
        public RelayCommand CloseUserOptionsCommand
        {
            get { return closeUserOptionCommand ?? (closeUserOptionCommand = new RelayCommand(() => ShowUserSubMenu = false)); }
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
                           () => navigationService.NavigateTo(ViewModelLocator.GAMES_PAGE_KEY, this.User)));


            }
        }

        public RelayCommand NavigateToPublisherPageCommand
        {
            get
            {
                return navigateToPublisherPageCommand?? (navigateToPublisherPageCommand = new RelayCommand(() => navigationService.NavigateTo(ViewModelLocator.PUBLISHER_PAGE_KEY)));
            }
        }

        /// <summary>
        /// Login command
        /// </summary>
        public RelayCommand LoginCommand
        {
            get
            {
                return loginCommand ?? (loginCommand = new RelayCommand(async () =>
                    {
                        MessageDialog dialog = null;
                        try
                        {
                            User = await login();

                            if(User == null)
                            {
                                dialog = new MessageDialog("Error while trying to login. Make sure that password is correct.");
                                dialog.Commands.Add(new UICommand("OK"));
                            }
                        }
                        catch (Exception ex)
                        {
                            dialog = new MessageDialog(ex.Message);

                            dialog.Commands.Add(new UICommand("OK"));
                        }
                        if (dialog != null)
                            await dialog.ShowAsync();

                    }
                        ));
            }
        }


        /// <summary>
        /// Register command
        /// </summary>
        public RelayCommand RegisterCommand
        {
            get
            {
                return registerCommand ?? (registerCommand = new RelayCommand(async () =>
                    {
                        MessageDialog messagedialog = null;

                        try
                        {
                            bool result = await register();

                            if (result == false)
                                throw new Exception("Register error. Username could be taken.");
                        }
                        catch (Exception ex)
                        {
                            // Message dialog - shows errors
                            messagedialog = new MessageDialog(ex.Message);


                            messagedialog.Commands.Add(new UICommand("Try again",
                                new UICommandInvokedHandler((IUICommand uiCommand) => { this.RegisterCommand.Execute(null); })));

                            messagedialog.Commands.Add(new UICommand("Cancel"));


                        }

                        if (messagedialog != null)
                            await messagedialog.ShowAsync();
                    }));
            }
        }

        /// <summary>
        /// Logout command
        /// </summary>
        public RelayCommand LogoutCommand
        {
            get
            {
                return logoutCommand ?? (logoutCommand = new RelayCommand(() =>
                {
                    UserLoggedinButtonVisibility = false;
                    RegisterAndLoginButtonVisibility = true;
                    LoginUserName = "";
                    User = null;
                    ShowUserSubMenu = false;
                    GameStore.WindowsApp.Common.UserInfo.Id = "";
                    GameStore.WindowsApp.Common.UserInfo.Token = "";
                    GameStore.WindowsApp.Common.UserInfo.Username = "";
                }));
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
                User result = await userService.FindAsync(loginUserName, loginPassword);
                GameStore.WindowsApp.Common.UserInfo.Username = loginUserName;


                if (!String.IsNullOrEmpty(loginUserName) && !String.IsNullOrEmpty(result.UserName))
                {
                    UserLoggedinButtonVisibility = true;

                    LoginFormVisibility = false;
                    RegisterFormVisibility = false;
                    RegisterAndLoginButtonVisibility = false;
                }
                else
                    return null;

                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        /// <summary>
        /// User do register user
        /// </summary>
        private async Task<bool> register()
        {
            try
            {
                bool result;

                // Chekc if password is same
                if (CheckRegisterFormPassword == UserToRegister.PasswordHash)
                {
                    result = await userService.RegisterUser(UserToRegister, UserToRegister.PasswordHash);

                    if (result)
                    {
                        LoginFormVisibility = false;
                        RegisterFormVisibility = false;
                    }
                }
                else
                {
                    // TODO Show invalid password message
                    result = false;
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