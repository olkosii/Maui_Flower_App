using System;

namespace Maui_Flower_App.MVVM.Models.Groups
{
    public class FlowerGroupGroup : List<FlowerGroup>
    {
        public string Name { get; set; }
        public FlowerGroupGroup(string name, List<FlowerGroup> flowerGroupGroup) : base(flowerGroupGroup)
        {
            Name = name;
        }
    }
}
