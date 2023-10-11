using Maui_Flower_App.MVVM.Models;
using System;

namespace Maui_Flower_App.Repositories.DI
{
    public interface IOrderRepository
    {

        Task<List<Order>> GetOrdersAsync();
        Task<Order> GetOrderAsync(int orderId);
        Task<bool> CreateOrderAsync(Order order);
        Task<bool> UpdateOrderAsync(Order order);
        Task<bool> DeleteOrderAsync(int orderId);
    }
}
