using Maui_Flower_App.MVVM.Models.Enums;
using SQLite;
using System;
using Color = Maui_Flower_App.MVVM.Models.Enums.Color;

namespace Maui_Flower_App.MVVM.Models
{
    [Table("Flowers")]
    public class Flower
    {
        [PrimaryKey, AutoIncrement, Indexed]
        public int Id { get; set; }
        public FlowerType Type { get; set; }
        public Color MainColor { get; set; }
        public string TypeName { get; set; }
        public double Length { get; set; }
        public int CountPerPackage { get; set; }
        public decimal PricePerUnit { get; set; }
        public string Image { get; set; }
    }
}
