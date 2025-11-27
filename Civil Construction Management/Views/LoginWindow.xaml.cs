using Civil_Construction_Management.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace Civil_Construction_Management.Views
{

    public partial class LoginWindow : Window
    {
        private LoginViewModel _viewModel;
        
        public LoginWindow()
        {

            InitializeComponent();

            _viewModel = App.ServiceProvider.GetRequiredService<LoginViewModel>();
            _viewModel.HideWindowAction = Hide;
            DataContext = _viewModel;
        }

    }
}
