using System;

namespace Maui_Flower_App.MVVM.Models
{
    public class Order
    {
        public string Id { get; set; }
        public string ClientId { get; set; }
        public List<Flower> Flowers { get; set; }
        public decimal TotalPrice { get; set; }
        public int TotalFlowersAmount { get; set; }
    }
}
