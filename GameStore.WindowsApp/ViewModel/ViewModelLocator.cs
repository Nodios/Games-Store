﻿/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocatorTemplate xmlns:vm="using:GameStore.WindowsApp.ViewModel"
                                   x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
*/

using System.Diagnostics.CodeAnalysis;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using GameStore.WindowsApp.Design;
using GameStore.WindowsApp.Model;
using GameStore.WindowsApp.Service.Common;
using GameStore.WindowsApp.Service;
using GameStore.WindowsApp.Views;

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
        public const string SecondPageKey = "SecondPage";
        public const string GamesPageKey = "GamesPage";

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
                SimpleIoc.Default.Register<IDataService, DesignDataService>();

                // My services
                SimpleIoc.Default.Register<IGamesService, GamesService>();
            }
            else
            {
                SimpleIoc.Default.Register<IDataService, DataService>();

                // My services
                SimpleIoc.Default.Register<IGamesService, GamesService>();
            }

            // Configure navigation service pages here
            var nav = new NavigationService();
            nav.Configure(ViewModelLocator.SecondPageKey, typeof(SecondPage));
            nav.Configure(ViewModelLocator.GamesPageKey, typeof(GamesPage));
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