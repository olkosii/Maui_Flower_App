using Maui_Flower_App.Deserializers;
using Maui_Flower_App.Helpers;
using Maui_Flower_App.MVVM.Models;
using Maui_Flower_App.Repositories.DI;
using Newtonsoft.Json;
using System.Text;

namespace Maui_Flower_App.Repositories
{
    //Not implementet repository for Firebase
    public sealed class ClientRepository : IClientRepository
    {
        private static readonly HttpClient _httpClient;

        static ClientRepository()
        {
            _httpClient = new HttpClient(new SocketsHttpHandler
            {
                PooledConnectionLifetime = TimeSpan.FromMinutes(1)
            });
        }

        public ClientRepository()
        {
        }

        public async Task<List<Client>> GetClientsAsync()
        {
            try
            {
                var response = await _httpClient
                    .GetAsync(Constants.FirebaseConstants.BaseUrl + Constants.FirebaseConstants.ClientsCollection + Constants.FirebaseConstants.JsonPostfix);

                if (response.IsSuccessStatusCode)
                    return await ClientDeserializer.DeserializeClientList(response);

                return new List<Client>();
            }
            catch (Exception ex)
            {
                return new List<Client> { };
            }
        }

        public async Task<Client> GetClientAsync(string clientId)
        {
            try
            {
                var response = await _httpClient
                    .GetAsync(Constants.FirebaseConstants.BaseUrl + clientId + Constants.FirebaseConstants.JsonPostfix);

                if (response.IsSuccessStatusCode)
                    return await ClientDeserializer.DeserializeClient(response);

                return new Client();
            }
            catch (Exception ex)
            {
                return new Client();
            }
        }

        public async Task<bool> CreateClientAsync(Client client)
        {
            try
            {
                var data = new StringContent(JsonConvert.SerializeObject(client), Encoding.UTF8);

                var response = await _httpClient
                    .PostAsync(Constants.FirebaseConstants.BaseUrl + Constants.FirebaseConstants.ClientsCollection + Constants.FirebaseConstants.JsonPostfix, data);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteClientAsync(string clientId)
        {
            try
            {
                HttpResponseMessage response = null;
                
                response = await _httpClient
                        .DeleteAsync(Constants.FirebaseConstants.BaseUrl + Constants.FirebaseConstants.ClientsCollection + clientId + Constants.FirebaseConstants.JsonPostfix);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateClientAsync(Client client)
        {
            throw new NotImplementedException();
        }
    }
}
