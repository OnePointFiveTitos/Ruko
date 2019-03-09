using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows;
using XneExtensions;

namespace Resources
{
    public class BoolToColorChoicesConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                return new BrushConverter().ConvertFromString((parameter as string).SplitDefault()[(bool)value ? 0 : 1]) as Brush;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return Brushes.Red; //indicates error in color string
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}