using GalaSoft.MvvmLight.Views;
using GameStore.WindowsApp.Common;
using GameStore.WindowsApp.ViewModel;
using GameStore.WindowsApp.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace GameStore.WindowsApp.Custom_controls
{
    public sealed partial class MenuOptions : UserControl
    {

        public MenuOptions()
        {
            this.InitializeComponent();
        }

        private void Cart_Click(object sender, RoutedEventArgs e)
        {
            NavigationService service = new NavigationService();
            service.Configure(ViewModelLocator.CART_PAGE_KEY, typeof(CartPage));
            service.NavigateTo(ViewModelLocator.CART_PAGE_KEY);
        }

        private void Account_Click(object sender, RoutedEventArgs e)
        {
            NavigationService service = new NavigationService();
            service.Configure(ViewModelLocator.ACCOUNT_PAGE_KEY, typeof(AccountPage));
            service.NavigateTo(ViewModelLocator.ACCOUNT_PAGE_KEY);
        }

        private void Order_Click(Object sender, RoutedEventArgs e)
        {
            NavigationService service = new NavigationService();
            service.Configure(ViewModelLocator.ORDER_PAGE_KEY, typeof(OrderPage));
            service.NavigateTo(ViewModelLocator.ORDER_PAGE_KEY);
        }

    }
}
