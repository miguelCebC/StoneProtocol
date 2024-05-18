using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace WpfApp1.NVVM.View
{
    public partial class VistaPrincipal : UserControl
    {
        private Point _startPoint;
        private bool _isDragging;
        private TranslateTransform _transform;

        public VistaPrincipal()
        {
            InitializeComponent();
            LoadComponents();
        }

        private void StackPanel_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var stackPanel = sender as StackPanel;
            if (stackPanel != null)
            {
                _startPoint = e.GetPosition(this);
                _transform = stackPanel.RenderTransform as TranslateTransform ?? new TranslateTransform();
                stackPanel.RenderTransform = _transform;
                _isDragging = true;
                stackPanel.CaptureMouse();
            }
        }

        private void StackPanel_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (_isDragging)
            {
                var stackPanel = sender as StackPanel;
                if (stackPanel != null)
                {
                    var currentPoint = e.GetPosition(this);
                    var offset = currentPoint.X - _startPoint.X;
                    var newTransformX = _transform.X + offset;

                    // Limitar el desplazamiento dentro del contenido
                    var maxOffset = ((FrameworkElement)stackPanel.Parent).ActualWidth - stackPanel.ActualWidth;
                    if (newTransformX < maxOffset)
                    {
                        newTransformX = maxOffset;
                    }
                    if (newTransformX > 0)
                    {
                        newTransformX = 0;
                    }

                    _transform.X = newTransformX;
                    _startPoint = currentPoint; // Reset start point for smoother dragging
                }
            }
        }

        private void StackPanel_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var stackPanel = sender as StackPanel;
            if (stackPanel != null)
            {
                _isDragging = false;
                stackPanel.ReleaseMouseCapture();
            }
        }

        private void StackPanel_TouchDown(object sender, TouchEventArgs e)
        {
            var stackPanel = sender as StackPanel;
            if (stackPanel != null)
            {
                _startPoint = e.GetTouchPoint(this).Position;
                _transform = stackPanel.RenderTransform as TranslateTransform ?? new TranslateTransform();
                stackPanel.RenderTransform = _transform;
                _isDragging = true;
                stackPanel.CaptureTouch(e.TouchDevice);
            }
        }

        private void StackPanel_TouchMove(object sender, TouchEventArgs e)
        {
            if (_isDragging)
            {
                var stackPanel = sender as StackPanel;
                if (stackPanel != null)
                {
                    var currentPoint = e.GetTouchPoint(this).Position;
                    var offset = currentPoint.X - _startPoint.X;
                    var newTransformX = _transform.X + offset;

                    // Limitar el desplazamiento dentro del contenido
                    var maxOffset = ((FrameworkElement)stackPanel.Parent).ActualWidth - stackPanel.ActualWidth;
                    if (newTransformX < maxOffset)
                    {
                        newTransformX = maxOffset;
                    }
                    if (newTransformX > 0)
                    {
                        newTransformX = 0;
                    }

                    _transform.X = newTransformX;
                    _startPoint = currentPoint; // Reset start point for smoother dragging
                }
            }
        }

        private void StackPanel_TouchUp(object sender, TouchEventArgs e)
        {
            var stackPanel = sender as StackPanel;
            if (stackPanel != null)
            {
                _isDragging = false;
                stackPanel.ReleaseTouchCapture(e.TouchDevice);
            }
        }
        private void LoadComponents()
        {
            List<ItemData> items = GetItemsFromDatabase();

            foreach (var item in items)
            {
                var component = new ProductDisplay();
                component.LoadData(item.ImagePath, item.Name, item.Description);
                HorizontalStackPanel1.Children.Add(component);
            }
        }

        private List<ItemData> GetItemsFromDatabase()
        {
            // Aquí va la lógica para obtener los datos de la base de datos.
            // Esto es solo un ejemplo:
            return new List<ItemData>
            {
                new ItemData { ImagePath = "path/to/image1.jpg", Name = "Item 1", Description = "Description for Item 1" },
                new ItemData { ImagePath = "path/to/image2.jpg", Name = "Item 2", Description = "Description for Item 2" }
            };
        }
    }


    public class ItemData
    {
        public string ImagePath { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }


}

