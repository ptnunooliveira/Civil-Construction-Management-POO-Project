using Civil_Construction_Management.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace Civil_Construction_Management
{

    public partial class MainWindow : Window
    {

        private MainWindowViewModel _viewModel;

        public MainWindow()
        {

            InitializeComponent();

            _viewModel = App.ServiceProvider.GetRequiredService<MainWindowViewModel>();
            DataContext = _viewModel;
        }
    }
}