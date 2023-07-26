using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace StockTable
{
    public class StockRowForegroundConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length < 3 || !(values[0] is double) || !(values[1] is Color) || !(values[2] is Color))
                return Brushes.Black; 

            double change = (double)values[0];
            Color risingColor = (Color)values[1];
            Color downingColor = (Color)values[2];

            if (change > 0)
                return new SolidColorBrush(risingColor);
            else if (change < 0)
                return new SolidColorBrush(downingColor);

            return Brushes.Gray; 
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}