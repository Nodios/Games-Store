using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.WindowsApp.ViewModel
{
    public class PublisherViewModel : ViewModelBase
    {
        #region Fields

        private readonly INavigationService navigationService;

        private string searchString;

        private RelayCommand goBack;

        #endregion

        #region Proporties

        /// <summary>
        /// Gets and sets search string
        /// </summary>
        public string SearchString
        {
            get { return searchString; }
            set { Set(() => this.SearchString, ref searchString, value); }
        }

        #endregion

        #region Constructor

        public PublisherViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }

        #endregion

        #region Commands

        public RelayCommand GoBack
        {
            get { return goBack ?? (goBack = new RelayCommand(() => navigationService.GoBack())); }
        }

        #endregion

        #region Private methods

        #endregion
    }
}
