using Civil_Construction_Management.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace Civil_Construction_Management.Views
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml.
    /// This window provides the user interface for user authentication.
    /// </summary>
    public partial class LoginWindow : Window
    {
        private LoginViewModel _viewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginWindow"/> class.
        /// Resolves the <see cref="LoginViewModel"/> using dependency injection,
        /// assigns it as the DataContext, and sets the hide window action.
        /// </summary>
        public LoginWindow()
        {
            InitializeComponent();

            // Retrieve the LoginViewModel from the dependency injection container
            _viewModel = App.ServiceProvider.GetRequiredService<LoginViewModel>();

            // Allows the ViewModel to hide this window programmatically
            _viewModel.HideWindowAction = Hide;

            // Sets the ViewModel as the DataContext for binding
            DataContext = _viewModel;
        }
    }
}