using System.Globalization;
using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace ICS_SIS.App.Converters
{
    public class DoubleToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value?.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (double.TryParse((string)value, out double result))
            {
                return result;
            }
            return 0;
        }
    }
}