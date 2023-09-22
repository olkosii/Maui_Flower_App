using SQLite;
using System;

namespace Maui_Flower_App.MVVM.Models
{
    public class Flower
    {
        [PrimaryKey, AutoIncrement, Indexed]
        public string Id { get; set; }
        public string TypeName { get; set; }
        public double Length { get; set; }
        public int CountPerPackage { get; set; }
        public decimal PricePerUnit { get; set; }
        public string Image { get; set; }
    }
}
