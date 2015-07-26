/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocatorTemplate xmlns:vm="using:GameStore.WindowsApp.ViewModel"
                                   x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using GameStore.WindowsApp.Service;
using GameStore.WindowsApp.Service.Common;
using GameStore.WindowsApp.Views;
using Microsoft.Practices.ServiceLocation;
using System.Diagnostics.CodeAnalysis;

namespace GameStore.WindowsApp.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class ViewModelLocator
    {
        #region Fields

        public const string SECOND_PAGE_KEY = "SecondPage";
        public const string GAMES_PAGE_KEY = "GamesPage";
        public const string MAIN_PAGE_KEY = "MainPage";

        #endregion

        /// <summary>
        /// Gets the Main property.
        /// </summary>
        [SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        [SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public GamesViewModel Games
        {
            get
            {
                return ServiceLocator.Current.GetInstance<GamesViewModel>();
            }
        }

        /// <summary>
        /// Register all services here 
        /// </summary>
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (ViewModelBase.IsInDesignModeStatic)
            {
                // My services
                SimpleIoc.Default.Register<IGamesService, GamesService>();
                SimpleIoc.Default.Register<IGameImageService, GameImageService>();
                SimpleIoc.Default.Register<IUserService, UserService>();
            }
            else
            {
                // My services
                SimpleIoc.Default.Register<IGamesService, GamesService>();
                SimpleIoc.Default.Register<IGameImageService, GameImageService>();
                SimpleIoc.Default.Register<IUserService, UserService>();
            }

            // Configure navigation service pages here
            var nav = new NavigationService();
            nav.Configure(ViewModelLocator.SECOND_PAGE_KEY, typeof(SecondPage));
            nav.Configure(ViewModelLocator.GAMES_PAGE_KEY, typeof(GamesPage));
            nav.Configure(ViewModelLocator.MAIN_PAGE_KEY, typeof(MainPage));
            SimpleIoc.Default.Register<INavigationService>(() => nav);

            // Register view models
            SimpleIoc.Default.Register<IDialogService, DialogService>();
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<GamesViewModel>();
        }

        /// <summary>
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup()
        {
        }
    }
}