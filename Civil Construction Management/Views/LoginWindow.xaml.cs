using Civil_Construction_Management.Models.Repositories;
using Civil_Construction_Management.ViewModel;
using Civil_Construction_Management.ViewModel.Services;
using System.Windows;

namespace Civil_Construction_Management.Views
{
    /// <summary>
    /// Lógica interna para LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private LoginViewModel _viewModel;
        public LoginWindow()
        {
            InitializeComponent();
            UserRepository userRepository = new UserRepository();
            AuthenticationService authService = new AuthenticationService(userRepository);

            _viewModel = new LoginViewModel(authService);
            _viewModel.HideWindowAction = Hide;
            DataContext = _viewModel;
        }

    }
}
