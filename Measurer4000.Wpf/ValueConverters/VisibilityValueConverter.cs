using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Measurer4000.ValueConverters
{
    public class VisibilityValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var visibilityValue = (bool)value;

            if(visibilityValue)
            {
                return Visibility.Visible;
            }

            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
