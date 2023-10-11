using Maui_Flower_App.Helpers;
using Maui_Flower_App.MVVM.Models;
using Maui_Flower_App.Repositories.DI;
using SQLite;
using System;

namespace Maui_Flower_App.Repositories
{
    public class SQLOrderRepository : IOrderRepository
    {
        private SQLiteConnection _databaseConnection;

        public SQLOrderRepository()
        {
            _databaseConnection =
                new SQLiteConnection(Constants.AppConstants.SqlLiteConstants.DatabasePath,
                                     Constants.AppConstants.SqlLiteConstants.Flags);

            _databaseConnection.CreateTable<Order>();
        }

        public async Task<List<Order>> GetOrdersAsync()
        {
            try
            {
                return _databaseConnection.Table<Order>().ToList();
            }
            catch (Exception)
            {
                return new List<Order>();
            }
        }

        public async Task<Order> GetOrderAsync(int orderId)
        {
            try
            {
                return _databaseConnection.Table<Order>().FirstOrDefault(c => c.Id == orderId);
            }
            catch (Exception)
            {
                return new Order();
            }
        }

        public async Task<bool> CreateOrderAsync(Order order)
        {
            int result = 0;
            try
            {
                result = _databaseConnection.Insert(order);

                return result > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteOrderAsync(int orderId)
        {
            try
            {
                var order = await GetOrderAsync(orderId);
                var result = _databaseConnection.Delete(order);

                return result > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateOrderAsync(Order order)
        {
            try
            {
                var result = _databaseConnection.Update(order);

                return result > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
