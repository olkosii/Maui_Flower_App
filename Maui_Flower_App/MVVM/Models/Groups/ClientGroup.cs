using System;

namespace Maui_Flower_App.MVVM.Models.Groups
{
    public class ClientGroup: List<Client>
    {
        public string Name { get; set; }

        public ClientGroup(string name, List<Client> clients) : base(clients)
        {
            Name = name;
        }
    }
}
