using Maui_Flower_App.Helpers;
using Maui_Flower_App.MVVM.Models;
using Maui_Flower_App.Repositories.DI;
using SQLite;
using System;

namespace Maui_Flower_App.Repositories
{
    public class SqlLiteClientRepository : IClientRepository<int>
    {
        private SQLiteConnection _databaseConnection;

        public SqlLiteClientRepository()
        {
            _databaseConnection =
                new SQLiteConnection(Constants.AppConstants.SqlLiteConstants.DatabasePath,
                                     Constants.AppConstants.SqlLiteConstants.Flags);

            _databaseConnection.CreateTable<Client<int>>();
        }

        public async Task<List<Client<int>>> GetClientsAsync()
        {
            try
            {
                return _databaseConnection.Table<Client<int>>().ToList();
            }
            catch (Exception ex)
            {
                return new List<Client<int>> { };
            }
        }

        public async Task<Client<int>> GetClientAsync(int clientId)
        {
            try
            {
                return _databaseConnection.Table<Client<int>>().FirstOrDefault(c => c.Id == clientId);
            }
            catch (Exception)
            {
                return new Client<int>();
            }
        }

        public async Task<bool> CreateClientAsync(Client<int> client)
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

        public async Task<bool> UpdateClientAsync(Client<int> client)
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
