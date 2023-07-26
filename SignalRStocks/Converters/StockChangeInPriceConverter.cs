using System;
using System.Globalization;
using System.Windows.Data;

namespace StockTable
{
    public class StockChangeInPriceConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values != null && values.Length == 2 && (values[0] is double v) && (values[1] is double v1))
            {
                return (v*v1).ToString("0.0000"); 
            }

            return 0.0;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}