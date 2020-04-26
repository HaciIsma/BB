using BakuBus.Model;
using System;
using System.Globalization;
using System.Windows.Data;

namespace BakuBus.Converter
{
    public class Converter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var type = (BusType)value;
            switch (type)
            {
                case BusType.CREALIS:
                    return "/Resources/CREALIS.jpg";
                case BusType.URBANWAY:
                    return "/Resources/URBANWAY.jpg";
                default:
                    return "/Resources/CREALIS.jpg";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
