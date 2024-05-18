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
        public string ImagePath { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ProductDisplay()
        {
            InitializeComponent();
            DataContext = this;
            Name = "ejemplo";
            Description = "Description";
            ImagePath = null;
        }

        public void LoadData(string imagePath, string name, string description)
        {
            ItemImage.Source = new BitmapImage(new Uri(imagePath, UriKind.RelativeOrAbsolute));
            ItemName.Text = name;
            Description = description;
        }

        private void ShowDescriptionPopup(object sender, RoutedEventArgs e)
        {
            DescriptionPopup.IsOpen = true;
        }

        private void CloseDescriptionPopup(object sender, RoutedEventArgs e)
        {
            DescriptionPopup.IsOpen = false;
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
