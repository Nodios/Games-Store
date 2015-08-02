using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using GameStore.WindowsApp.Model;
using GameStore.WindowsApp.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace GameStore.WindowsApp.ViewModel
{
    public class PublisherViewModel : ViewModelBase
    {
        #region Fields

        private readonly INavigationService navigationService;
        private readonly IPublisherService publisherService;

        private int pageNumber;

        private string searchString;
        private Publisher publisher;
        private IEnumerable<Publisher> publishers;
        private bool previousButtonVisible;
        private bool goForwardButtonVisible;
        private Support support;
        private bool publisherDetailsVisible;

        private RelayCommand goBack;
        private RelayCommand getPublishersCommand;
        private RelayCommand backInList;
        private RelayCommand forwardInList;
        private RelayCommand<Guid> getSupportCommand;

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

        /// <summary>
        /// Gets and sets publisher
        /// </summary>
        public Publisher Publisher
        {
            get { return publisher; }
            set { Set(() => this.Publisher, ref publisher, value); }
        }

        /// <summary>
        /// Gets and sets publishers
        /// </summary>
        public IEnumerable<Publisher> Publishers
        {
            get { return publishers; }
            set { Set(() => this.Publishers, ref publishers, value); }
        }

        /// <summary>
        /// Sets visibility of previous button
        /// </summary>
        public bool PreviousButtonVisible
        {
            get { return previousButtonVisible; }
            set { Set(() => this.PreviousButtonVisible, ref previousButtonVisible, value); }
        }

        /// <summary>
        /// Gets and sets visibility of forward button
        /// </summary>
        public bool GoForwardButtonVisible
        {
            get { return goForwardButtonVisible; }
            set { Set(() => this.GoForwardButtonVisible, ref goForwardButtonVisible, value); }
        }

        /// <summary>
        /// gets and sets support
        /// </summary>
        public Support Support
        {
            get { return support; }
            set { Set(() => this.Support, ref support, value); }
        }

        /// <summary>
        /// Publisher details
        /// </summary>
        public bool PublisherDetailsVisible
        {
            get { return publisherDetailsVisible; }
            set { Set(() => this.PublisherDetailsVisible, ref publisherDetailsVisible, value); }
        }

        #endregion

        #region Constructor

        public PublisherViewModel(INavigationService navigationService, IPublisherService publisherService)
        {
            this.navigationService = navigationService;
            this.publisherService = publisherService;

            pageNumber = 1;
            Publishers = new List<Publisher>();
            Publisher = new Model.Publisher();
            Support = new Model.Support();
            SearchString = "";
            previousButtonVisible = false;
            publisherDetailsVisible = false;
        }

        #endregion

        #region Commands

        public RelayCommand GoBack
        {
            get { return goBack ?? (goBack = new RelayCommand(() => navigationService.GoBack())); }
        }

        /// <summary>
        /// Get publishers command
        /// </summary>
        public RelayCommand GetPublishersCommand
        {
            get
            {
                return getPublishersCommand ?? (getPublishersCommand = new RelayCommand(async () =>
                    {
                        MessageDialog msg = null;
                        PublisherDetailsVisible = false;

                        // Empty so that there isn't exception thrown
                        Publisher = null;
                        Support = null;
                        try
                        { 
                            pageNumber = 1;
                            Publishers = await getPublishers();
                        }
                        catch (Exception ex)
                        {
                            msg = new MessageDialog(ex.Message);
                            msg.Commands.Add(new UICommand("OK"));
                        }
                        if (msg != null)
                            await msg.ShowAsync();
                    }));
            }
        }

        /// <summary>
        /// Back in list button
        /// </summary>
        public RelayCommand BackInList
        {
            get
            {
                return backInList ?? (backInList = new RelayCommand(async () =>
                {
                    MessageDialog msg = null;
                    try
                    {
                        // Paging 
                        pageNumber--;
                        if (pageNumber <= 1)
                        {
                            PreviousButtonVisible = false;
                            pageNumber = 1;
                        }
                        else
                            PreviousButtonVisible = true;

                        Publishers = await getPublishers();

                    }
                    catch (Exception ex)
                    {
                        msg = new MessageDialog(ex.Message);
                        msg.Commands.Add(new UICommand("OK"));
                    }
                    if (msg != null)
                        await msg.ShowAsync();
                }));
            }
        }

        /// <summary>
        /// Forward in list 
        /// </summary>
        public RelayCommand ForwardInList
        {
            get
            {
                return forwardInList ?? (forwardInList = new RelayCommand(async () =>
                {
                    pageNumber++;
                    Publishers = await getPublishers();
                    if (Publishers.Count() >= 5)
                        GoForwardButtonVisible = true;
                    else
                    {
                        GoForwardButtonVisible = false;
                        if (pageNumber > 1)
                            pageNumber--;
                    }

                }));
            }
        }

        /// <summary>
        /// Gets support
        /// </summary>
        public RelayCommand<Guid> GetSupportCommand
        {
            get
            {
                return getSupportCommand ?? (getSupportCommand = new RelayCommand<Guid>(async (id) =>
                {
                    if (publisher != null)
                    {
                        MessageDialog msg = null;
                        try
                        {
                            Support = await getSupport(id);

                            // show publisher details
                            if (Support != null)
                                PublisherDetailsVisible = true;
                        }
                        catch (Exception ex)
                        {
                            // Handle exception
                            msg = new MessageDialog(ex.Message);
                            msg.Commands.Add(new UICommand("Try again",
                                new UICommandInvokedHandler((IUICommand requiresParam) => { this.GetSupportCommand.Execute(id); })));
                            msg.Commands.Add(new UICommand("Cancel"));

                            // hide publisher details if exception
                            PublisherDetailsVisible = false;
                        }
                        if (msg != null)
                            await msg.ShowAsync(); 
                    }
                }));
            }
        }

        #endregion

        #region Private methods

        // Gets publishers
        private async Task<IEnumerable<Publisher>> getPublishers()
        {
            try
            {           
                IEnumerable<Publisher> result;
                if (searchString.Length > 0)
                {
                    result = await publisherService.GetRangeAsync(SearchString, new Utilities.GenericFilter(pageNumber, 5));
                }
                else
                {
                    result = await publisherService.GetRangeAsync(new Utilities.GenericFilter(pageNumber, 5));
                }

                if (result.Count() >= 5)
                    goForwardButtonVisible = true;

                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private async Task<Support> getSupport(Guid id)
        {
            try
            {
                return await publisherService.GetSupportAsync(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion
    }
}
