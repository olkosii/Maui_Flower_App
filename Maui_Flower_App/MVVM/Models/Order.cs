using SQLite;
using System;

namespace Maui_Flower_App.MVVM.Models
{
    public class Order<TId>
    {
        [PrimaryKey, AutoIncrement, Indexed]
        public TId Id { get; set; }
        public TId ClientId { get; set; }
        public List<Flower<TId>> Flowers { get; set; }
        public decimal TotalPrice { get; set; }
        public int TotalFlowersAmount { get; set; }
    }
}
