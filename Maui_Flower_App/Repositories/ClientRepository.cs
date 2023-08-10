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
        private HttpClient _httpClient;

        public ClientRepository()
        {
        }

        public async Task<List<Client>> GetClientsAsync()
        {
            try
            {
                using (_httpClient = new HttpClient())
                {
                    var response = await _httpClient.GetAsync(Constants.FirebaseConstants.baseUrl + Constants.FirebaseConstants.ClientsCollection);
                    
                    if (response.IsSuccessStatusCode)
                        return await ClientDeserializer.DeserializeClientList(response);
                }

                return new List<Client> { };
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
                using (_httpClient = new HttpClient())
                {
                    var response = await _httpClient.GetAsync(Constants.FirebaseConstants.baseUrl + clientId + ".json");

                    if (response.IsSuccessStatusCode)
                        return await ClientDeserializer.DeserializeClient(response);
                }

                return new Client();
            }
            catch (Exception ex)
            {
                return new Client();
            }
        }

        public async Task CreateClientAsync(Client client)
        {
            try
            {
                using(_httpClient = new HttpClient())
                {
                    var data = new StringContent(JsonConvert.SerializeObject(client), Encoding.UTF8);

                    var response = await _httpClient
                        .PostAsync(Constants.FirebaseConstants.baseUrl + Constants.FirebaseConstants.ClientsCollection, data);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public Task DeleteClientAsync(Client client)
        {
            throw new NotImplementedException();
        }

        public Task UpdateClientAsync(Client client)
        {
            throw new NotImplementedException();
        }
    }
}
