using Maui_Flower_App.Deserializers;
using Maui_Flower_App.Helpers;
using Maui_Flower_App.MVVM.Models;
using Maui_Flower_App.Repositories.DI;
using Newtonsoft.Json;
using System;
using System.Text;

namespace Maui_Flower_App.Repositories
{
    public class FirebaseFlowerRepository
    {
        private static readonly HttpClient _httpClient;

        static FirebaseFlowerRepository()
        {
            _httpClient = new HttpClient(new SocketsHttpHandler
            {
                PooledConnectionLifetime = TimeSpan.FromMinutes(1)
            });
        }

        public async Task<List<Flower>> GetDistinctGroupsOfFlowersGroupAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync(
                    Constants.FirebaseConstants.BaseUrl +
                    Constants.FirebaseConstants.FlowersCollection +
                    Constants.FirebaseConstants.JsonPostfix);


                if (response.IsSuccessStatusCode)
                {
                    var flowers = await FlowerDeserializer.DeserializeFlowerList(response);
                    return flowers.DistinctBy(f => f.TypeName).ToList();
                }

                return new List<Flower>();
            }
            catch (Exception ex)
            {
                return new List<Flower> { };
            }
        }

        public async Task<List<Flower>> GetFlowersByTypeName(string typeName)
        {
            try
            {
                var response = await _httpClient.GetAsync(
                    Constants.FirebaseConstants.BaseUrl +
                    Constants.FirebaseConstants.FlowersCollection +
                    Constants.FirebaseConstants.JsonPostfix);


                if (response.IsSuccessStatusCode)
                {
                    var flowers = await FlowerDeserializer.DeserializeFlowerList(response);
                    return flowers.DistinctBy(f => f.TypeName == typeName).ToList();
                }

                return new List<Flower>();
            }
            catch (Exception ex)
            {
                return new List<Flower> { };
            }
        }

        public async Task<Flower> GetFlowerAsync(int flowerId)
        {
            try
            {
                var response = await _httpClient.GetAsync(
                    Constants.FirebaseConstants.BaseUrl +
                    Constants.FirebaseConstants.FlowersCollection +
                    flowerId.ToString() + Constants.FirebaseConstants.JsonPostfix);

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

        public async Task<bool> DeleteFlowerAsync(int flowerId)
        {
            try
            {
                var response = await _httpClient.DeleteAsync(
                    Constants.FirebaseConstants.BaseUrl +
                    Constants.FirebaseConstants.FlowersCollection +
                    flowerId.ToString() + Constants.FirebaseConstants.JsonPostfix);

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
                    flower.Id.ToString() + "/" +
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
