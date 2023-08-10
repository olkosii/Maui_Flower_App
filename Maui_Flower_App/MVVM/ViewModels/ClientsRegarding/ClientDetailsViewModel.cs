using Maui_Flower_App.MVVM.Models;
using PropertyChanged;
using System;
using System.Windows.Input;

namespace Maui_Flower_App.MVVM.ViewModels.ClientsRegarding
{
    [AddINotifyPropertyChangedInterface]
    public class ClientDetailsViewModel
    {
        #region Propetries

        public Client Client { get; set; }

        #endregion

        public ClientDetailsViewModel(Client client)
        {
            Client = client;
        }

        #region Commands

        public ICommand UpdateCommand => new Command(UpdateClient);

        #endregion

        #region Commands methods

        private void UpdateClient()
        {
            var client = Client;
        }

        #endregion
    }
}
