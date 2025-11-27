using Civil_Construction_Management.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace Civil_Construction_Management.Views
{
    /// <summary>
    /// Lógica interna para AddEmployeeWindow.xaml
    /// </summary>
    public partial class AddEmployeeWindow : Window
    {

        private EmployeeViewModel _viewModel;
        public AddEmployeeWindow()
        {

            InitializeComponent();
            _viewModel = App.ServiceProvider.GetRequiredService<EmployeeViewModel>();
            DataContext = _viewModel;
            _viewModel.HideWindowAction = Close;
        }
    }
}
