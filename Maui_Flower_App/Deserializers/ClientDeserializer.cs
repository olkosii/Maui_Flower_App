using Maui_Flower_App.MVVM.Models;
using System;

namespace Maui_Flower_App.Deserializers
{
    public static class ClientDeserializer
    {
        //Not working
        public static async Task<List<Client>> DeserializeClientList(HttpResponseMessage responseMessage)
        {
			try
			{
				var clientDictionary = await Deserializer.Deserialize<Client>(responseMessage);
				var clientList = new List<Client>(clientDictionary.Count);

				foreach (var client in clientDictionary)
				{
					clientList.Add(new Client
					{
						//Id = client.Key,
                        Name = client.Value.Name,
                        Address = client.Value.Address,
						PhoneNumber = client.Value.PhoneNumber,
					});
				}

				return clientList;
			}
			catch (Exception)
			{
				throw;
			}
        }

        //Not working
        public static async Task<Client> DeserializeClient(HttpResponseMessage responseMessage)
		{
            var clientDictionary = await Deserializer.Deserialize<Client>(responseMessage);

			var client = new Client
			{
				//Id = clientDictionary.Keys.FirstOrDefault(),
				Name = clientDictionary.Values.FirstOrDefault().Name,
				Address = clientDictionary.Values.FirstOrDefault().Address,
				PhoneNumber = clientDictionary.Values.FirstOrDefault().PhoneNumber,
			};

			return client;
        }
    }
}
