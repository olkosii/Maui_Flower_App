using Maui_Flower_App.Deserializers;
using Maui_Flower_App.Helpers;
using Maui_Flower_App.MVVM.Models;
using Maui_Flower_App.Repositories.DI;
using Newtonsoft.Json;
using System;
using System.Text;

namespace Maui_Flower_App.Repositories
{
    public class FirebaseFlowerRepository : IFlowerRepository<string>
    {
        private static readonly HttpClient _httpClient;

        static FirebaseFlowerRepository()
        {
            _httpClient = new HttpClient(new SocketsHttpHandler
            {
                PooledConnectionLifetime = TimeSpan.FromMinutes(1)
            });
        }

        public async Task<List<Flower<string>>> GetDistinctFlowersAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync(
                    Constants.FirebaseConstants.BaseUrl +
                    Constants.FirebaseConstants.FlowersCollection +
                    Constants.FirebaseConstants.JsonPostfix);


                if (response.IsSuccessStatusCode)
                {
                    var flowers = await FlowerDeserializer<string>.DeserializeFlowerList(response);
                    return flowers.DistinctBy(f => f.TypeName).ToList();
                }

                return new List<Flower<string>>();
            }
            catch (Exception ex)
            {
                return new List<Flower<string>> { };
            }
        }

        public async Task<List<Flower<string>>> GetFlowersByTypeName(string typeName)
        {
            try
            {
                var response = await _httpClient.GetAsync(
                    Constants.FirebaseConstants.BaseUrl +
                    Constants.FirebaseConstants.FlowersCollection +
                    Constants.FirebaseConstants.JsonPostfix);


                if (response.IsSuccessStatusCode)
                {
                    var flowers = await FlowerDeserializer<string>.DeserializeFlowerList(response);
                    return flowers.DistinctBy(f => f.TypeName == typeName).ToList();
                }

                return new List<Flower<string>>();
            }
            catch (Exception ex)
            {
                return new List<Flower<string>> { };
            }
        }

        public async Task<Flower<string>> GetFlowerAsync(string flowerId)
        {
            try
            {
                var response = await _httpClient.GetAsync(
                    Constants.FirebaseConstants.BaseUrl +
                    Constants.FirebaseConstants.FlowersCollection +
                    flowerId + Constants.FirebaseConstants.JsonPostfix);

                if (response.IsSuccessStatusCode)
                    return await FlowerDeserializer<string>.DeserializeFlower(response);

                return new Flower<string>();
            }
            catch (Exception ex)
            {
                return new Flower<string>();
            }
        }

        public async Task<bool> CreateFlowerAsync(Flower<string> flower)
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

        public async Task<bool> UpdateFlowerAsync(Flower<string> flower)
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
