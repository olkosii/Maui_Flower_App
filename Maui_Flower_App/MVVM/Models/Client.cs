using System;
using SQLite;

namespace Maui_Flower_App.MVVM.Models
{
    [Table("Clients")]
    public class Client
    {
        [PrimaryKey, AutoIncrement, Indexed]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
