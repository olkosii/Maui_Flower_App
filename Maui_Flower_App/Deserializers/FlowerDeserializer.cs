using Maui_Flower_App.MVVM.Models;
using System;

namespace Maui_Flower_App.Deserializers
{
    public class FlowerDeserializer<TFlowerId>
    {
        public static async Task<List<Flower<TFlowerId>>> DeserializeFlowerList(HttpResponseMessage responseMessage)
        {
            try
            {
                var flowerDictionary = await Deserializer.Deserialize<TFlowerId,Flower<TFlowerId>>(responseMessage);
                var flowerList = new List<Flower<TFlowerId>>(flowerDictionary.Count);

                foreach (var flower in flowerDictionary)
                {
                    flowerList.Add(new Flower<TFlowerId>
                    {
                        Id = flower.Key,
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

        public static async Task<Flower<TFlowerId>> DeserializeFlower(HttpResponseMessage responseMessage)
        {
            var flowerDictionary = await Deserializer.Deserialize<TFlowerId,Flower<TFlowerId>>(responseMessage);

            var flower = new Flower<TFlowerId>
            {
                Id = flowerDictionary.Keys.FirstOrDefault(),
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
