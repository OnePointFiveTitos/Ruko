using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using XneExtensions;

namespace Resources
{
    /// <summary>
    /// Ex: "_Activate|De_activate" for parameter where true returns "_Activate" and false returns "De_activate"
    /// </summary>
    public class BoolToStringChoicesConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            => (parameter as string).SplitDefault()[(bool)value ? 0 : 1];

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}