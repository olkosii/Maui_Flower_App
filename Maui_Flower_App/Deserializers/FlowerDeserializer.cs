using Maui_Flower_App.MVVM.Models;
using System;

namespace Maui_Flower_App.Deserializers
{
    public class FlowerDeserializer
    {
        public static async Task<List<Flower>> DeserializeFlowerList(HttpResponseMessage responseMessage)
        {
            try
            {
                var flowerDictionary = await Deserializer.Deserialize<Flower>(responseMessage);
                var flowerList = new List<Flower>(flowerDictionary.Count);

                foreach (var flower in flowerDictionary)
                {
                    flowerList.Add(new Flower
                    {
                        Id = int.Parse(flower.Key),
                        TypeName = flower.Value.TypeName,
                        Length = flower.Value.Length,
                        CountPerPackage = flower.Value.CountPerPackage,
                        PricePerUnit = flower.Value.PricePerUnit,
                        Image = flower.Value.Image,
                    });
                }

                return flowerList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<Flower> DeserializeFlower(HttpResponseMessage responseMessage)
        {
            var flowerDictionary = await Deserializer.Deserialize<Flower>(responseMessage);

            var flower = new Flower
            {
                Id = int.Parse(flowerDictionary.Keys.FirstOrDefault()),
                TypeName = flowerDictionary.Values.FirstOrDefault().TypeName,
                Length = flowerDictionary.Values.FirstOrDefault().Length,
                CountPerPackage = flowerDictionary.Values.FirstOrDefault().CountPerPackage,
                PricePerUnit = flowerDictionary.Values.FirstOrDefault().PricePerUnit,
                Image = flowerDictionary.Values.FirstOrDefault().Image,
            };

            return flower;
        }
    }
}
