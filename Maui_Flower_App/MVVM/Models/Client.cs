using SQLite;
using System;

namespace Maui_Flower_App.MVVM.Models
{
    [Table("Clients")]
    public class Client<TClientId>
    {
        [PrimaryKey,AutoIncrement,Indexed]
        public TClientId Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
