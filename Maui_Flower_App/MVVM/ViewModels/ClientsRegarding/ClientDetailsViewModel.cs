using Maui_Flower_App.Helpers;
using Maui_Flower_App.MVVM.Models;
using Maui_Flower_App.Repositories.DI;
using PropertyChanged;
using System;
using System.Windows.Input;

namespace Maui_Flower_App.MVVM.ViewModels.ClientsRegarding
{
    [AddINotifyPropertyChangedInterface]
    public class ClientDetailsViewModel
    {
        #region Propetries

        public Client<int> Client { get; set; }
        private IClientRepository<int> _clientRepository;

        #endregion

        public ClientDetailsViewModel(Client<int> client)
        {
            Client = client;
            _clientRepository = ServiceHelper.GetService<IClientRepository<int>>();
        }

        #region Commands

        public ICommand UpdateCommand => new Command(UpdateClient);

        #endregion

        #region Commands methods

        private async void UpdateClient()
        {
            var result = await _clientRepository.UpdateClientAsync(Client);

            if (result)
                await Application.Current.MainPage.DisplayAlert(Constants.AppConstants.Message.MessageWord, Constants.AppConstants.Message.UserUpdated, "Ok");
            else
                await Application.Current.MainPage.DisplayAlert(Constants.AppConstants.Error.ErrorWord, Constants.AppConstants.Error.ErrorMessage, "Ok");

            await Application.Current.MainPage.Navigation.PopAsync();
        }

        #endregion
    }
}
