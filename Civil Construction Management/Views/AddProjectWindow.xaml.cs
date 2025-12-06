using Civil_Construction_Management.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace Civil_Construction_Management.Views
{
    /// <summary>
    /// Lógica interna para AddProjectWindow.xaml
    /// </summary>
    public partial class AddProjectWindow : Window
    {

        private ProjectViewModel _viewModel;

        public AddProjectWindow()
        {
            InitializeComponent();
            _viewModel = App.ServiceProvider.GetRequiredService<ProjectViewModel>();
            DataContext = _viewModel;
            _viewModel.HideWindowAction = Hide;
        }
    }
}
