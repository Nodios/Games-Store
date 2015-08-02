using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using GameStore.WindowsApp.Model;
using GameStore.WindowsApp.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace GameStore.WindowsApp.ViewModel
{
    public class AccountViewModel : ViewModelBase
    {
        #region Fields

        private readonly INavigationService navigationService;
        private readonly IUserService userService;

        private bool showChangePassword;
        private bool showChangeEmail;
        private User user;

        // Change pass fields
        private string userPassword;
        private string newPassword;
        private string confirmNewPassword;

        // Change user
        private string newEmail;
        private string confirmNewEmail;

        private RelayCommand loadedCommand;
        private RelayCommand showChangePasswordCommand;
        private RelayCommand showChangeEmailCommand;
        private RelayCommand submitPasswordCommand;
        private RelayCommand submitEmailCommand;

        #endregion

        #region Proporties

        public bool ShowChangePassword
        {
            get { return showChangePassword; }
            set { Set(() => this.ShowChangePassword, ref showChangePassword, value); }
        }

        public bool ShowChangeEmail
        {
            get { return showChangeEmail; }
            set { Set(() => this.ShowChangeEmail, ref showChangeEmail, value); }
        }

        public User User
        {
            get { return user; }
            set { Set(() => this.User, ref user, value); }
        }

        public string UserPassword
        {
            get { return userPassword; }
            set { Set(() => this.UserPassword, ref userPassword, value); }
        }

        public string NewPassword
        {
            get { return newPassword; }
            set { Set(() => this.NewPassword, ref newPassword, value); }
        }

        public string ConfirmNewPassword
        {
            get { return confirmNewPassword; }
            set { Set(() => this.ConfirmNewPassword, ref confirmNewPassword, value); }
        }

        public string NewEmail
        {
            get { return newEmail; }
            set { Set(() => this.NewEmail, ref newEmail, value); }
        }

        public string ConfirmNewEmail
        {
            get { return confirmNewEmail; }
            set { Set(() => this.ConfirmNewEmail, ref confirmNewEmail, value); }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="navigationService">Navigation service</param>
        /// <param name="userService">User service</param>
        public AccountViewModel(INavigationService navigationService, IUserService userService)
        {
            this.navigationService = navigationService;
            this.userService = userService;

            ShowChangePassword = false;
            ShowChangeEmail = false;

            NewPassword = "";
            ConfirmNewPassword = "";
            UserPassword = "";
            NewEmail = "";
            ConfirmNewEmail = "";
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
                        User = await userService.GetAsync(GameStore.WindowsApp.Common.UserInfo.Username);
                    }));
            }
        }

        /// <summary>
        /// Show change email form
        /// </summary>
        public RelayCommand ShowChangeEmailCommand
        {
            get
            {
                return showChangeEmailCommand ?? (showChangeEmailCommand = new RelayCommand(() =>
                {
                    ShowChangeEmail = true;
                    ShowChangePassword = false;
                }));
            }
        }

        /// <summary>
        /// Shows change password form
        /// </summary>
        public RelayCommand ShowChangePasswordCommand
        {
            get
            {
                return showChangePasswordCommand ?? (showChangePasswordCommand = new RelayCommand(() =>
                {
                    ShowChangeEmail = false;
                    ShowChangePassword = true;
                }));
            }
        }

        public RelayCommand SubmitPasswordCommand
        {
            get
            {
                return submitPasswordCommand ?? (submitPasswordCommand = new RelayCommand(async () =>
                {
                    MessageDialog msg = null;
                    try
                    {
                        if(NewPassword != ConfirmNewPassword && NewPassword.Length >= 6)
                        {
                            msg = new MessageDialog("Please make sure that new password and confirm new password fields are same and of length 6 or greater.");
                            msg.Commands.Add(new UICommand("OK"));
                            return;
                        }

                        bool result = await changePassword(User.Id, UserPassword, NewPassword);

                        if (result)
                            msg = new MessageDialog("Password changed.");
                        else
                            msg = new MessageDialog("Couldn't change password. Please try again.");
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

        public RelayCommand SubmitEmailCommand
        {
            get
            {
                return submitEmailCommand ?? (submitEmailCommand = new RelayCommand(async () =>
                    {
                        MessageDialog dialog = null;
                        try
                        {
                            User = await changeEmail(NewEmail, ConfirmNewEmail);
                            if (User != null)
                                dialog = new MessageDialog("Email changed.");
                            else
                                dialog = new MessageDialog("Error while trying to change email.");
                        }
                        catch (Exception ex)
                        {
                            dialog = new MessageDialog(ex.Message);
                        }
                        await dialog.ShowAsync();
                    }));
            }
        }

        #endregion

        #region private methods

        private async Task<bool> changePassword(string userId, string oldPassowrd, string newPassword)
        {
            try
            {
                return await userService.UpdatePasswordAsync(userId, oldPassowrd, newPassword);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private async Task<User> changeEmail(string email, string password)
        {
            try
            {
                User.Email = email;
                return await userService.UpdateEmailOrUsernameAsync(User, password);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        #endregion
    }
}
