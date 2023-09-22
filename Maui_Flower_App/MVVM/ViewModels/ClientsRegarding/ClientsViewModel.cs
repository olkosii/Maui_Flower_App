using Maui_Flower_App.Helpers;
using Maui_Flower_App.MVVM.Models;
using Maui_Flower_App.MVVM.Views.ClientRegarding;
using Maui_Flower_App.Repositories.DI;
using PropertyChanged;
using System;
using System.Windows.Input;

namespace Maui_Flower_App.MVVM.ViewModels.ClientsRegarding
{
    [AddINotifyPropertyChangedInterface]
    public class ClientsViewModel
    {
        #region Properties

        private List<Client> Clients { get; set; }
        public List<Client> FilteredClients { get; set; }
        private IClientRepository<int> _clientRepository { get; set; }

        #endregion

        public ClientsViewModel()
        {
            _clientRepository = ServiceHelper.GetService<IClientRepository<int>>();
        }

        #region Commands

        public ICommand RedirectToAddClientForm => new Command(RedirectToForm);
        public ICommand SearchCommand => new Command<string>(Search);
        public ICommand ItemSelectedCommand => new Command<Client>(RedirectToClientDetails);

        #endregion

        #region Command Methods

        public void Search(string clientName)
        {
            FilteredClients = Clients.Where(c => c.Name.ToLower().Contains(clientName.ToLower())).ToList();
        }

        public void RedirectToForm()
        {
            Application.Current.MainPage.Navigation.PushAsync(new AddClientView());
        }

        public void RedirectToClientDetails(Client client)
        {
            Application.Current.MainPage.Navigation.PushAsync(new ClientDetailsView(client));
        }

        public async Task DeleteClientAsync(Client client)
        {
            var alertResult = await Application.Current.MainPage
                    .DisplayAlert(Constants.AppConstants.Message.Attention,
                    Constants.AppConstants.Message.DeleteAttentionMessage + $"({client.Name})", "Ok", "Cancel");

            if (alertResult)
            {
                var result = await _clientRepository.DeleteClientAsync(client.Id);

                if (result)
                {
                    var clientIndex = Clients.FindIndex(c => c.Id == client.Id);
                    Clients.RemoveAt(clientIndex);
                    FilteredClients.RemoveAt(clientIndex);

                    await Application.Current.MainPage.DisplayAlert(Constants.AppConstants.Message.MessageWord, Constants.AppConstants.Message.UserDeleted, "Ok");
                }
                else
                    await Application.Current.MainPage.DisplayAlert(Constants.AppConstants.Error.ErrorWord, Constants.AppConstants.Error.ErrorMessage, "Ok");
            }
        }

        #endregion

        public async Task InitializeClientsAsync()
        {
            Clients = await _clientRepository.GetClientsAsync();
            FilteredClients = new List<Client>(Clients);
        }
    }
}
