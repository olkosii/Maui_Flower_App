using Maui_Flower_App.MVVM.Models;
using System;
using System.Collections.ObjectModel;

namespace Maui_Flower_App.Repositories.DI
{
    public interface IClientRepository
    {
        Task<List<Client>> GetClientsAsync();
        Task<Client> GetClientAsync(string id);
        Task CreateClientAsync(Client client);
        Task UpdateClientAsync(Client client);
        Task DeleteClientAsync(Client client);
    }
}
