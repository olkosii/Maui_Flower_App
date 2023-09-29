using Maui_Flower_App.MVVM.Models;
using Maui_Flower_App.MVVM.Models.Groups;
using System;

namespace Maui_Flower_App.Repositories.DI
{
    public interface IFlowerRepository
    {
        Task<List<FlowerGroupGroup>> GetDistinctGroupsOfFlowersGroupAsync();
        Task<List<Flower>> GetDistinctFlowersAsync();
        Task<Flower> GetFlowerAsync(int flowerId);
        Task<bool> CreateFlowerAsync(Flower flower);
        Task<bool> UpdateFlowerAsync(Flower flower);
        Task<bool> DeleteFlowerAsync(int flowerId);
    }
}
