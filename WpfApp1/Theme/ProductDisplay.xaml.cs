using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WpfApp1
{
    public partial class ProductDisplay : UserControl
    {
   

        public ProductDisplay()
        {
            InitializeComponent();
            DataContext = this;
        }

        public void LoadData(string imagePath, string name, string description)
        {
            ItemImage.Source = new BitmapImage(new Uri(imagePath, UriKind.RelativeOrAbsolute));
            ItemName.Text = name;
            ItemDescription.Text = description;
        }

        private void ToggleDescription(object sender, RoutedEventArgs e)
        {
            ItemDescription.Visibility = ItemDescription.Visibility == Visibility.Collapsed ? Visibility.Visible : Visibility.Collapsed;
        }
    }

    public class RandomColorConverter : IValueConverter
    {
        private static Random random = new Random();

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return Color.FromRgb((byte)random.Next(256), (byte)random.Next(256), (byte)random.Next(256));
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
