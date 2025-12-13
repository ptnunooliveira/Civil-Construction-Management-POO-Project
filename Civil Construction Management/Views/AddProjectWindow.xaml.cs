using Civil_Construction_Management.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace Civil_Construction_Management.Views
{
    /// <summary>
    /// Interaction logic for AddProjectWindow.xaml.
    /// This window is responsible for creating or editing a project.
    /// </summary>
    public partial class AddProjectWindow : Window
    {
        private ProjectViewModel _viewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddProjectWindow"/> class.
        /// Resolves the <see cref="ProjectViewModel"/> through dependency injection,
        /// sets it as the DataContext, and assigns the close/hide action.
        /// </summary>
        public AddProjectWindow()
        {
            InitializeComponent();

            // Resolve the ViewModel instance from the DI container
            _viewModel = App.ServiceProvider.GetRequiredService<ProjectViewModel>();

            // Bind the ViewModel to the window
            DataContext = _viewModel;

            // Allows the ViewModel to request the window to be hidden/closed
            _viewModel.HideWindowAction = Hide;
        }
    }
}