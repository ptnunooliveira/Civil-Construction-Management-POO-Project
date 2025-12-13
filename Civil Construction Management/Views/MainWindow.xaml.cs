using Civil_Construction_Management.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace Civil_Construction_Management
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// This window serves as the main container for displaying different
    /// views such as employee and project listings.
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel _viewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// Resolves the <see cref="MainWindowViewModel"/> using dependency injection
        /// and sets it as the DataContext for data binding.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            // Retrieve the MainWindowViewModel from the dependency injection container
            _viewModel = App.ServiceProvider.GetRequiredService<MainWindowViewModel>();

            // Sets the ViewModel as the DataContext for binding
            DataContext = _viewModel;
        }
    }
}