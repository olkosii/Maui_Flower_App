using Maui_Flower_App.Helpers;
using Maui_Flower_App.MVVM.Models;
using Maui_Flower_App.Repositories.DI;
using PropertyChanged;
using System;

namespace Maui_Flower_App.MVVM.ViewModels.OrdersRegarding
{
    [AddINotifyPropertyChangedInterface]
    public class NewOrderViewModel
    {
        #region Properties

        public Order Order { get; set; }
        public IOrderRepository _orderRepository { get; set; }
        public IClientRepository _clientRepository { get; set; }
        public List<Client> Clients { get; set; }

        #endregion

        public NewOrderViewModel()
        {
            _clientRepository = ServiceHelper.GetService<IClientRepository>();
            _orderRepository = ServiceHelper.GetService<IOrderRepository>();
            Order = new Order();
            InitializeClientsAsync();
        }

        #region Commands

        #endregion

        #region Commands Methods

        #endregion

        private async void InitializeClientsAsync()
        {
            Clients = await _clientRepository.GetClientsAsync();
        }
    }
}
