using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
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
    public class OrderViewModel : ViewModelBase
    {
        #region Fields

        private readonly IOrderService orderService;

        private ICollection<Order> orders;

        private RelayCommand loadedCommand;

        #endregion

        #region Proporties

        public ICollection<Order> Orders
        {
            get { return orders; }
            set { Set(() => this.Orders, ref orders, value); }
        }

        #endregion

        #region Constructor

        public OrderViewModel(IOrderService orderService)
        {
            this.orderService = orderService;


            Orders = new List<Order>();
        }

        #endregion

        #region Commands

        public RelayCommand LoadedCommand
        {
            get
            {
                return loadedCommand ?? (loadedCommand = new RelayCommand(async () =>
                    {
                        MessageDialog dialog = null;
                        try
                        {
                            Orders = await getOrders();
                        }
                        catch (Exception ex)
                        {
                            dialog = new MessageDialog(ex.Message);
                        }
                        if (dialog != null)
                            await dialog.ShowAsync();
                    }));
            }
        }

        #endregion

        #region Private methods

        private async Task<ICollection<Order>> getOrders()
        {
            try
            {
                return await orderService.GetAsync(GameStore.WindowsApp.Common.UserInfo.Id);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        
        #endregion
    }
}
