using Maui_Flower_App.MVVM.Models;
using System;

namespace Maui_Flower_App.Repositories.DI
{
    public interface IFlowerRepository<TFlowerId>
    {
        Task<List<Flower<TFlowerId>>> GetDistinctFlowersAsync();
        Task<Flower<TFlowerId>> GetFlowerAsync(TFlowerId flowerId);
        Task<bool> CreateFlowerAsync(Flower<TFlowerId> flower);
        Task<bool> UpdateFlowerAsync(Flower<TFlowerId> flower);
        Task<bool> DeleteFlowerAsync(TFlowerId flowerId);
    }
}
