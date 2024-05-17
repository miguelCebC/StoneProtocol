using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfApp1.Nucleo;
using WpfApp1.NVVM.View;

namespace WpfApp1.NVVM.ViewModel
{
    class ViewModelPrincipal : ObjetoObservable
    {
        public ViewModel1 VM1 { get; set; }

        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public ICommand ShowHomeViewCommand { get; private set; }
        public ICommand ShowProductsViewCommand { get; private set; }
        public ICommand ShowStoreViewCommand { get; private set; }
        public ICommand ShowVistaPrincipalCommand { get; private set; }
        public ICommand CloseCommand { get; private set; }

        public ViewModelPrincipal()
        {
            VM1 = new ViewModel1();
            CurrentView = new VistaPrincipal(); // Establecer VistaPrincipal como la vista inicial

            ShowHomeViewCommand = new RelayCommand(_ => ShowHomeView());
            ShowProductsViewCommand = new RelayCommand(_ => ShowProductsView());
            ShowStoreViewCommand = new RelayCommand(_ => ShowStoreView());
            ShowVistaPrincipalCommand = new RelayCommand(_ => ShowVistaPrincipal());
            CloseCommand = new RelayCommand(_ => CloseApplication());
        }

        public void ShowHomeView()
        {
            CurrentView = new VistaPrincipal();
        }

        public void ShowProductsView()
        {
            CurrentView = new VistaProducto();
        }

        public void ShowStoreView()
        {
            //CurrentView = new StoreView();
        }

        public void ShowVistaPrincipal()
        {
            CurrentView = new VistaPrincipal();
        }

        public void CloseApplication()
        {
            Application.Current.Shutdown();
        }
    }
}
