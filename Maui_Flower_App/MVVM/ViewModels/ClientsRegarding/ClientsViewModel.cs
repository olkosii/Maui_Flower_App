using Maui_Flower_App.Helpers;
using Maui_Flower_App.MVVM.Models;
using Maui_Flower_App.MVVM.Views.ClientRegarding;
using Maui_Flower_App.Repositories.DI;
using PropertyChanged;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Maui_Flower_App.MVVM.ViewModels.ClientsRegarding
{
    [AddINotifyPropertyChangedInterface]
    public class ClientsViewModel
    {
        #region Properties

        private List<Client> Clients { get; set; }
        public List<Client> FilteredClients { get; set; }
        public IClientRepository _clientRepository { get; private set; }

        #endregion

        public ClientsViewModel()
        {
            _clientRepository = ServiceHelper.GetService<IClientRepository>();
        }

        #region Commands

        public ICommand AddClient => new Command<Client>(AddClientAsync);
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

        public void AddClientAsync(Client newClient)
        {
            Clients.Add(newClient);
        }

        #endregion

        public async Task InitializeClientsAsync()
        {
            Clients = await _clientRepository.GetClientsAsync();
            FilteredClients = new List<Client>(Clients);
        }
    }
}
