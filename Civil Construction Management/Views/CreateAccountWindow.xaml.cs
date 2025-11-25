using Civil_Construction_Management.Models.Repositories;
using Civil_Construction_Management.ViewModel.Services;
using Civil_Construction_Management.ViewModels;
using System.Windows;

namespace Civil_Construction_Management.Views
{

    public partial class CreateAccountWindow : Window
    {

        private CreateAccountViewModel _createAccount;

        public CreateAccountWindow()
        {

            InitializeComponent();
            UserRepository userRepository = new UserRepository();
            AuthenticationService authService = new AuthenticationService(userRepository);

            _createAccount = new CreateAccountViewModel(authService);
            _createAccount.HideWindowAction = Hide;
            DataContext = _createAccount;
        }
    }
}
