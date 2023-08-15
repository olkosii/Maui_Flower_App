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
        private IClientRepository _clientRepository { get; set; }

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

        public async void CreateClient()
        {
            var result = await _clientRepository.CreateClientAsync(Client);

            if (result)
                await Application.Current.MainPage.DisplayAlert(Constants.AppConstants.Message.MessageWord, Constants.AppConstants.Message.UserAdded, "Ok");
            else
                await Application.Current.MainPage.DisplayAlert(Constants.AppConstants.Error.ErrorWord, Constants.AppConstants.Error.ErrorMessage, "Ok");

            await Application.Current.MainPage.Navigation.PopAsync();
        }

        #endregion
    }
}
