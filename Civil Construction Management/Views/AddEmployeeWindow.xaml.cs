using Civil_Construction_Management.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace Civil_Construction_Management.Views
{
    /// <summary>
    /// Interaction logic for AddEmployeeWindow.
    /// This window is responsible for creating or editing an Employee through the EmployeeViewModel.
    /// </summary>
    public partial class AddEmployeeWindow : Window
    {
        /// <summary>
        /// The ViewModel instance associated with this window.
        /// It is resolved through dependency injection.
        /// </summary>
        private readonly EmployeeViewModel _viewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddEmployeeWindow"/> class.
        /// Sets up the ViewModel via dependency injection and configures the DataContext.
        /// </summary>
        public AddEmployeeWindow()
        {
            InitializeComponent();

            // Resolve the EmployeeViewModel using the application's ServiceProvider
            _viewModel = App.ServiceProvider.GetRequiredService<EmployeeViewModel>();

            // Bind the window's DataContext to the ViewModel
            DataContext = _viewModel;

            // Assign the close action so the ViewModel can close this window programmatically
            _viewModel.HideWindowAction = Hide;
        }
    }
}