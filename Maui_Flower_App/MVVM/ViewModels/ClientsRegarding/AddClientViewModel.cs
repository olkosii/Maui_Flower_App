using System;
using System.Windows.Input;
using PropertyChanged;
using Maui_Flower_App.MVVM.Models;
using Maui_Flower_App.Repositories.DI;
using Maui_Flower_App.Helpers;

namespace Maui_Flower_App.MVVM.ViewModels.ClientsRegarding
{
    [AddINotifyPropertyChangedInterface]
    public class AddClientViewModel
    {
        #region Properties

        public Client Client { get; set; }
        public IClientRepository _clientRepository { get; private set; }

        #endregion

        public AddClientViewModel()
        {
            Client = new Client();
            _clientRepository = ServiceHelper.GetService<IClientRepository>();
        }

        #region Commands

        public ICommand SaveCommand => new Command(CreateClient);

        #endregion

        #region Commands Methods

        public void CreateClient()
        {
            _clientRepository.CreateClientAsync(Client);
            Application.Current.MainPage.Navigation.PopAsync();
        }

        #endregion
    }
}
