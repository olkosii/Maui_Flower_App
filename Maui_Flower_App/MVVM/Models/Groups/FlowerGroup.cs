using System;

namespace Maui_Flower_App.MVVM.Models.Groups
{
    public class FlowerGroup : List<Flower>
    {
        public string ColorName { get; set; }

        public FlowerGroup(string name, List<Flower> flowers) : base(flowers)
        {
            ColorName = name;
        }
    }
}
