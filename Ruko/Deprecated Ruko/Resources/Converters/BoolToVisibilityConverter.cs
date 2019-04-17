using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using XneExtensions;

namespace Resources
{
    /// <summary>
    /// true : false - false : true
    /// </summary>
    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            => (Visibility)int.Parse((parameter as string).SplitDefault()[(bool)value ? 0 : 1]);

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}