using Maui_Flower_App.MVVM.Models;
using System;

namespace Maui_Flower_App.Repositories.DI
{
    public interface IFlowerRepository
    {
        Task<List<Flower>> GetFlowersAsync();
        Task<Flower> GetFlowerAsync(string flowerId);
        Task<bool> CreateFlowerAsync(Flower flower);
        Task<bool> UpdateFlowerAsync(Flower flower);
        Task<bool> DeleteFlowerAsync(string flowerId);
    }
}
