using Maui_Flower_App.MVVM.Models;
using System;

namespace Maui_Flower_App.Deserializers
{
    public static class ClientDeserializer
    {
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
						Id = int.Parse(client.Key),
                        Name = client.Value.Name,
                        Address = client.Value.Address,
						City = client.Value.City,
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

		public static async Task<Client> DeserializeClient(HttpResponseMessage responseMessage)
		{
            var clientDictionary = await Deserializer.Deserialize<Client>(responseMessage);

			var client = new Client
			{
				Id = int.Parse(clientDictionary.Keys.FirstOrDefault()),
				Name = clientDictionary.Values.FirstOrDefault().Name,
				Address = clientDictionary.Values.FirstOrDefault().Address,
				City = clientDictionary.Values.FirstOrDefault().City,
				PhoneNumber = clientDictionary.Values.FirstOrDefault().PhoneNumber,
			};

			return client;
        }
    }
}
