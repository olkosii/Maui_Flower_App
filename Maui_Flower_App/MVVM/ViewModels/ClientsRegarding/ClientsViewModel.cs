using Maui_Flower_App.MVVM.Models;
using Maui_Flower_App.MVVM.Views.ClientRegarding;
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

        #endregion

        public ClientsViewModel()
        {
            Clients = new List<Client>()
            {
                new Client(){Id = "1", Name = "Sasha", Address = "Lviv", PhoneNumber = "063-29-86-787"},
                new Client(){Id = "2", Name = "Dima", Address = "Vin", PhoneNumber = "063-29-86-787"},
                new Client(){Id = "3", Name = "Nastia", Address = "Dnipro", PhoneNumber = "063-29-86-787"}
            };

            FilteredClients = new List<Client>(Clients);
        }

        #region Commands

        public ICommand AddClient => new Command<Client>(AddClientAsync);
        public ICommand RedirectToAddClientForm => new Command(RedirectToForm);
        public ICommand SearchCommand => new Command<string>(Search);

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

        public void AddClientAsync(Client newClient)
        {
            Clients.Add(newClient);
        }

        #endregion
    }
}
