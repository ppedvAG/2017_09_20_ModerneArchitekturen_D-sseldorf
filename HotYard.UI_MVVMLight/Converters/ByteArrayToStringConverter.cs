using System;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace HotYard.UI_MVVMLight.Converters
{
    internal class ByteArrayToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var data = (byte[])value;
            return Encoding.UTF8.GetString(data);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var data = (string)value;
            return Encoding.UTF8.GetBytes(data);
        }
    }
}
