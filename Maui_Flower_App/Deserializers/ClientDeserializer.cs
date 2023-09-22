using Maui_Flower_App.MVVM.Models;
using System;

namespace Maui_Flower_App.Deserializers
{
    public static class ClientDeserializer<TClientId>
    {
        
        public static async Task<List<Client<TClientId>>> DeserializeClientList(HttpResponseMessage responseMessage)
        {
			try
			{
				var clientDictionary = await Deserializer.Deserialize<TClientId,Client<TClientId>>(responseMessage);
				var clientList = new List<Client<TClientId>>(clientDictionary.Count);

				foreach (var client in clientDictionary)
				{
					clientList.Add(new Client<TClientId>
					{
						Id = client.Key,
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

        
        public static async Task<Client<TClientId>> DeserializeClient(HttpResponseMessage responseMessage)
		{
            var clientDictionary = await Deserializer.Deserialize<TClientId, Client<TClientId>>(responseMessage);

			var client = new Client<TClientId>
			{
				Id = clientDictionary.Keys.FirstOrDefault(),
				Name = clientDictionary.Values.FirstOrDefault().Name,
				Address = clientDictionary.Values.FirstOrDefault().Address,
				PhoneNumber = clientDictionary.Values.FirstOrDefault().PhoneNumber,
			};

			return client;
        }
    }
}
