using Maui_Flower_App.MVVM.Models;
using System;

namespace Maui_Flower_App.Repositories.DI
{
    public interface IClientRepository<TClientId>
    {
        Task<List<Client<TClientId>>> GetClientsAsync();
        Task<Client<TClientId>> GetClientAsync(TClientId clientId);
        Task<bool> CreateClientAsync(Client<TClientId> client);
        Task<bool> UpdateClientAsync(Client<TClientId> client);
        Task<bool> DeleteClientAsync(TClientId clientId);
    }
}
