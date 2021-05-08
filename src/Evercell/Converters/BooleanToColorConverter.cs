using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Evercell.Converters
{
    class BooleanToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is bool boolean))
            {
                return Brushes.WhiteSmoke;
            }
            else
            {
                bool concrete = boolean;

                if (concrete)
                {
                    return Brushes.YellowGreen;
                }
                else
                {
                    return Brushes.WhiteSmoke;
                }
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
