using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace StockTable
{
    public class StockChangeToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is double))
                return null; 

            double change = (double)value;
            if (change > 0)
                {
                    BitmapImage image = new();
                    image.BeginInit();
                    image.UriSource = new Uri("pack://Application:,,,/Resources/up.png");
                    image.EndInit();
                    return image;
                }
            else if (change < 0)
                {
                    BitmapImage image = new();
                    image.BeginInit();
                    image.UriSource = new Uri("pack://Application:,,,/Resources/down.png");
                    image.EndInit();
                    return image;
                }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}