using Maui_Flower_App.Helpers;
using Maui_Flower_App.MVVM.Models;
using Maui_Flower_App.Repositories.DI;
using SQLite;
using System;

namespace Maui_Flower_App.Repositories
{
    public class SQLClientRepository : IClientRepository
    {
        private SQLiteConnection _databaseConnection;

        public SQLClientRepository()
        {
            _databaseConnection =
                new SQLiteConnection(Constants.AppConstants.SqlLiteConstants.DatabasePath,
                                     Constants.AppConstants.SqlLiteConstants.Flags);

            _databaseConnection.CreateTable<Client>();
        }

        public async Task<bool> CreateClientAsync(Client client)
        {
            int result = 0;
            try
            {
                result = _databaseConnection.Insert(client);

                return result > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteClientAsync(int clientId)
        {
            try
            {
                var client = GetClientAsync(clientId);
                var result = _databaseConnection.Delete(client);

                return result > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<Client> GetClientAsync(int clientId)
        {
            try
            {
                return _databaseConnection.Table<Client>().FirstOrDefault(c => c.Id == clientId);
            }
            catch (Exception)
            {
                return new Client();
            }
        }

        public async Task<List<Client>> GetClientsAsync()
        {
            try
            {
                return _databaseConnection.Table<Client>().ToList();
            }
            catch (Exception ex)
            {
                return new List<Client> { };
            }
        }

        public async Task<bool> UpdateClientAsync(Client client)
        {
            try
            {
                var result = _databaseConnection.Update(client);

                return result > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
