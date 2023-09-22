using System;
using System.Text.Json;

namespace Maui_Flower_App.Deserializers
{
    public static class Deserializer
    {
        public static async Task<Dictionary<TKey,TValue>> Deserialize<TKey,TValue>(HttpResponseMessage responseMessage)
        {
            try
            {
                return JsonSerializer.Deserialize<Dictionary<TKey, TValue>>(await responseMessage.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
