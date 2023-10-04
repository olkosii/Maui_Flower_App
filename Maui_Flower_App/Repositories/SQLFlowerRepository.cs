using Maui_Flower_App.Helpers;
using Maui_Flower_App.MVVM.Models;
using Maui_Flower_App.MVVM.Models.Groups;
using Maui_Flower_App.Repositories.DI;
using SQLite;
using System;

namespace Maui_Flower_App.Repositories
{
    public class SQLFlowerRepository : IFlowerRepository
    {
        private SQLiteConnection _databaseConnection;

        public SQLFlowerRepository()
        {
            _databaseConnection =
               new SQLiteConnection(Constants.AppConstants.SqlLiteConstants.DatabasePath,
                                    Constants.AppConstants.SqlLiteConstants.Flags);

            _databaseConnection.CreateTable<Flower>();
        }

        public async Task<List<Flower>> GetDistinctFlowersAsync()
        {
            try
            {
                return _databaseConnection.Table<Flower>().DistinctBy(f => f.TypeName).ToList();
            }
            catch (Exception)
            {
                return new List<Flower>();
            }
        }

        public async Task<List<Flower>> GetFlowerGroupByName(string flowerName)
        {
            try
            {
                return _databaseConnection.Table<Flower>()
                    .Where(f => f.TypeName == flowerName).OrderBy(f => f.Length).ToList();
            }
            catch (Exception)
            {
                return new List<Flower>();
            }
        }

        //NOT WORKING
        public async Task<List<FlowerGroupGroup>> GetDistinctGroupsOfFlowersGroupAsync()
        {
            try
            {
                var fgByColor = _databaseConnection.Table<Flower>().DistinctBy(f => f.TypeName).OrderBy(f => f.MainColor)
                    .GroupBy(f => f.MainColor).Select(fg => new FlowerGroup(fg.Key.ToString(), fg.ToList())).ToList();


                return new List<FlowerGroupGroup>();
            }
            catch (Exception)
            {
                return new List<FlowerGroupGroup>();
            }
        }

        public async Task<Flower> GetFlowerAsync(int flowerId)
        {
            try
            {
                return _databaseConnection.Table<Flower>().FirstOrDefault(c => c.Id == flowerId);
            }
            catch (Exception)
            {
                return new Flower();
            }
        }

        public async Task<bool> DeleteFlowerAsync(int flowerId)
        {
            try
            {
                var flower = await GetFlowerAsync(flowerId);
                var result = _databaseConnection.Delete(flower);

                return result > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> CreateFlowerAsync(Flower flower)
        {
            int result = 0;
            try
            {
                result = _databaseConnection.Insert(flower);

                return result > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateFlowerAsync(Flower flower)
        {
            try
            {
                var result = _databaseConnection.Update(flower);

                return result > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
