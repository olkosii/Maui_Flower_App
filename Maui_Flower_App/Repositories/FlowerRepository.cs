using Maui_Flower_App.Deserializers;
using Maui_Flower_App.Helpers;
using Maui_Flower_App.MVVM.Models;
using Maui_Flower_App.Repositories.DI;
using Newtonsoft.Json;
using System;
using System.Text;

namespace Maui_Flower_App.Repositories
{
    public class FlowerRepository : IFlowerRepository
    {
        private static readonly HttpClient _httpClient;

        static FlowerRepository()
        {
            _httpClient = new HttpClient(new SocketsHttpHandler
            {
                PooledConnectionLifetime = TimeSpan.FromMinutes(1)
            });
        }

        public async Task<List<Flower>> GetFlowersAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync(
                    Constants.FirebaseConstants.BaseUrl +
                    Constants.FirebaseConstants.ClientsCollection +
                    Constants.FirebaseConstants.JsonPostfix);

                if (response.IsSuccessStatusCode)
                    return await FlowerDeserializer.DeserializeFlowerList(response);

                return new List<Flower>();
            }
            catch (Exception ex)
            {
                return new List<Flower> { };
            }
        }

        public async Task<Flower> GetFlowerAsync(string flowerId)
        {
            try
            {
                var response = await _httpClient.GetAsync(
                    Constants.FirebaseConstants.BaseUrl +
                    Constants.FirebaseConstants.FlowersCollection +
                    flowerId + Constants.FirebaseConstants.JsonPostfix);

                if (response.IsSuccessStatusCode)
                    return await FlowerDeserializer.DeserializeFlower(response);

                return new Flower();
            }
            catch (Exception ex)
            {
                return new Flower();
            }
        }

        public async Task<bool> CreateFlowerAsync(Flower flower)
        {
            try
            {
                var data = new StringContent(JsonConvert.SerializeObject(flower), Encoding.UTF8);

                var response = await _httpClient.PostAsync(
                    Constants.FirebaseConstants.BaseUrl +
                    Constants.FirebaseConstants.FlowersCollection +
                    Constants.FirebaseConstants.JsonPostfix, data);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteFlowerAsync(string flowerId)
        {
            try
            {
                var response = await _httpClient.DeleteAsync(
                    Constants.FirebaseConstants.BaseUrl +
                    Constants.FirebaseConstants.FlowersCollection +
                    flowerId + Constants.FirebaseConstants.JsonPostfix);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateFlowerAsync(Flower flower)
        {
            try
            {
                var data = new StringContent(JsonConvert.SerializeObject(flower), Encoding.UTF8);

                var response = await _httpClient.PutAsync(
                    Constants.FirebaseConstants.BaseUrl +
                    Constants.FirebaseConstants.ClientsCollection +
                    flower.Id + "/" +
                    Constants.FirebaseConstants.JsonPostfix, data);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
