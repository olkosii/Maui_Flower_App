using Maui_Flower_App.MVVM.Models;
using Maui_Flower_App.MVVM.Models.Groups;
using System;

namespace Maui_Flower_App.Repositories.DI
{
    public interface IFlowerRepository
    {
        Task<List<Flower>> GetDistinctFlowersAsync();
        Task<List<Flower>> GetFlowerGroupByName(string flowerName);
        Task<List<FlowerGroupGroup>> GetDistinctGroupsOfFlowerGroupsAsync();
        Task<Flower> GetFlowerAsync(int flowerId);
        Task<bool> DeleteFlowerAsync(int flowerId);
        Task<bool> CreateFlowerAsync(Flower flower);
        Task<bool> UpdateFlowerAsync(Flower flower);
    }
}
