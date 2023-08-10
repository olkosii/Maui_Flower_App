using System;
using System.Text.Json;

namespace Maui_Flower_App.Deserializers
{
    public static class Deserializer
    {
        public static async Task<Dictionary<string,T>> Deserialize<T>(HttpResponseMessage responseMessage)
        {
            try
            {
                return JsonSerializer.Deserialize<Dictionary<string, T>>(await responseMessage.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
