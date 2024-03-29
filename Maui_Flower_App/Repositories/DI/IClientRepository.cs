﻿using Maui_Flower_App.MVVM.Models;
using Maui_Flower_App.MVVM.Models.Groups;
using System;

namespace Maui_Flower_App.Repositories.DI
{
    public interface IClientRepository
    {
        Task<List<ClientGroup>> GetClientsGroupAsync();
        Task<List<Client>> GetClientsAsync();
        Task<Client> GetClientAsync(int clientId);
        Task<bool> CreateClientAsync(Client client);
        Task<bool> UpdateClientAsync(Client client);
        Task<bool> DeleteClientAsync(int clientId);
    }
}
