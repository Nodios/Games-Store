using GalaSoft.MvvmLight.Threading;
using GameStore.WindowsApp.Common;
using System;
using System.Diagnostics;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace GameStore.WindowsApp
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        // About PAGE STATES : https://msdn.microsoft.com/en-us/library/windows/apps/hh986968.aspx

        private readonly bool saveToCloud;

        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            // If false saves user data locally
            saveToCloud = false;

            InitializeComponent();
            Suspending += OnSuspending;

            // Event subscriber for unhandled events
            UnhandledException += new UnhandledExceptionEventHandler(unhandledException);
        }

        // Invoked when unhandled event occurs
        static void unhandledException(object sender, UnhandledExceptionEventArgs args)
        {
            //TODO create some sort of notification service for unhandled exceptions

            Exception e = (Exception)args.Exception;
            Debug.WriteLine("MyHandler caught : " + e.Message);
        }

      

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected async override void OnLaunched(LaunchActivatedEventArgs e)
        {

#if DEBUG
            if (System.Diagnostics.Debugger.IsAttached)
            {
                this.DebugSettings.EnableFrameRateCounter = true;
            }
#endif

            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();
                // Set the default language
                rootFrame.Language = Windows.Globalization.ApplicationLanguages.Languages[0];

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    // Load state from previously suspended application
                    ApplicationDataContainer dataContainer;

                    if (!saveToCloud)
                    {
                        dataContainer = ApplicationData.Current.LocalSettings;

                        if(dataContainer.Values.ContainsKey("username"))
                            UserInfo.Username = dataContainer.Values["username"].ToString();
                    }
                    else
                    {
                        dataContainer = ApplicationData.Current.RoamingSettings;

                        if (dataContainer.Values.ContainsKey("username"))
                            UserInfo.Username = dataContainer.Values["username"].ToString();
                    }

                    await SuspensionManager.RestoreAsync();
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
                DispatcherHelper.Initialize();
            }

            if (rootFrame.Content == null)
            {
                // When the navigation stack isn't restored navigate to the first page,
                // configuring the new page by passing required information as a navigation
                // parameter
                rootFrame.Navigate(typeof(MainPage), e.Arguments);
            }
            // Ensure the current window is active
            Window.Current.Activate();
        }

        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private async void OnSuspending(object sender, SuspendingEventArgs e)
        {
            ApplicationDataContainer dataContainer;

            // Save to local setting or cloud
            if (!saveToCloud)
            {
                dataContainer = ApplicationData.Current.LocalSettings;
                dataContainer.Values["username"] = UserInfo.Username;
            }
            else
            {
                dataContainer = ApplicationData.Current.RoamingSettings;
                dataContainer.Values["username"] = UserInfo.Username;
            }

            var deferral = e.SuspendingOperation.GetDeferral();
            // Save application state and stop any background activity
            await SuspensionManager.SaveAsync();
            deferral.Complete();


        }
    }
}
