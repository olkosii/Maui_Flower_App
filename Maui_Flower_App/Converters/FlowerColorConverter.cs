using Maui_Flower_App.MVVM.Models.Enums;
using System;
using System.Globalization;
using Color = Maui_Flower_App.MVVM.Models.Enums.Color;

namespace Maui_Flower_App.Converters
{
    public class FlowerColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Enum.Parse(typeof(Color), value.ToString());
        }
    }
}
