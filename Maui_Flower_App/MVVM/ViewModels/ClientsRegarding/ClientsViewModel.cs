﻿using Maui_Flower_App.Helpers;
using Maui_Flower_App.MVVM.Models;
using Maui_Flower_App.MVVM.Models.Groups;
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
        
        private List<ClientGroup> Clients { get; set; }
        public List<ClientGroup> FilteredClients { get; set; }
        private IClientRepository _clientRepository { get; set; }

        #endregion

        public ClientsViewModel()
        {
            _clientRepository = ServiceHelper.GetService<IClientRepository>();
        }

        #region Commands

        public ICommand RedirectToAddClientForm => new Command(RedirectToForm);
        public ICommand SearchCommand => new Command<string>(Search);
        public ICommand ItemSelectedCommand => new Command<Client>(RedirectToClientDetails);

        #endregion

        #region Command Methods

        public void Search(string clientName)
        {
            List<ClientGroup> cg = new List<ClientGroup>();

            foreach (var clientGroup in Clients)
            {
                var filteredGroup = clientGroup.Where(c => c.Name.ToUpper().Contains(clientName.ToUpper())).ToList();

                if(filteredGroup.Count > 0)
                    cg.Add(new ClientGroup(clientGroup.Name, filteredGroup));
            }

            FilteredClients = cg;
        }

        public void RedirectToForm()
        {
            Application.Current.MainPage.Navigation.PushAsync(new AddClientView());
        }

        public void RedirectToClientDetails(Client client)
        {
            if(client != null)
                Application.Current.MainPage.Navigation.PushAsync(new ClientDetailsView(client));
        }
 
        public async Task DeleteClientAsync(Client client)
        {
            var alertResult = await Application.Current.MainPage
                    .DisplayAlert(Constants.AppConstants.Message.Attention,
                    Constants.AppConstants.Message.DeleteClientAttentionMessage + $"({client.Name})", "Ok", "Cancel");

            if (alertResult)
            {
                var result = await _clientRepository.DeleteClientAsync(client.Id);

                if (result)
                {
                    var clientGroup = FilteredClients.FirstOrDefault(cg => cg.Name == client.City);
                    var clientIndex = clientGroup.FindIndex(c => c.Id == client.Id);

                    clientGroup.RemoveAt(clientIndex);

                    if(clientGroup.Count == 0)
                    {
                        Clients.Remove(clientGroup);
                        FilteredClients.Remove(clientGroup);
                    }

                    await Application.Current.MainPage.DisplayAlert(Constants.AppConstants.Message.MessageWord, Constants.AppConstants.Message.UserDeleted, "Ok");
                }
                else
                    await Application.Current.MainPage.DisplayAlert(Constants.AppConstants.Error.ErrorWord, Constants.AppConstants.Error.ErrorMessage, "Ok");
            }
        }

        #endregion

        public async Task InitializeClientsAsync()
        {
            Clients = await _clientRepository.GetClientsGroupAsync();
            FilteredClients = new List<ClientGroup>(Clients);
        }
    }
}
