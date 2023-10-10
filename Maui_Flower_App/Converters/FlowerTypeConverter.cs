using Maui_Flower_App.MVVM.Models.Enums;
using System;
using System.Globalization;

namespace Maui_Flower_App.Converters
{
    public class FlowerTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Enum.GetName(typeof(FlowerType), value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Enum.Parse(typeof(FlowerType), value.ToString());
        }
    }
}
