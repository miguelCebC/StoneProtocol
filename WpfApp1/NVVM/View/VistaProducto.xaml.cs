using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    public partial class VistaProducto : UserControl
    {
        public VistaProducto()
        {
            InitializeComponent();
            LoadCategories();
        }

        private void LoadCategories()
        {
            // Aquí se cargarán las categorías de la base de datos o de una lista estática.
            CategoryComboBox.Items.Add("Electrónica");
            CategoryComboBox.Items.Add("Ropa");
            CategoryComboBox.Items.Add("Hogar");
            CategoryComboBox.Items.Add("Juguetes");
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Aquí se manejará la lógica para guardar el producto en la base de datos.
            string productName = ProductNameTextBox.Text;
            string priceText = PriceTextBox.Text;
            string category = CategoryComboBox.SelectedItem as string;

            if (decimal.TryParse(priceText, out decimal price) && !string.IsNullOrEmpty(productName) && !string.IsNullOrEmpty(category))
            {
                // Guardar el producto en la base de datos
                MessageBox.Show($"Producto guardado:\nNombre: {productName}\nPrecio: {price}\nCategoría: {category}");
            }
            else
            {
                MessageBox.Show("Por favor, complete todos los campos correctamente.");
            }
        }
    }
}
