using Civil_Construction_Management.ViewModel.Interfaces;
using Civil_Construction_Management.Views;
using System.Windows;
using System.Windows.Input;

namespace Civil_Construction_Management.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {

        #region Private Fields

        private IAuthenticationService _authenticationService;      
        private string _username;
        private string _password;

        #endregion

        #region Public Properties
        public Action? HideWindowAction { get; set; }
        public ICommand LoginCommand { get; }
        public ICommand CreateAccountPageCommand { get; }

        public string Username
        {
            get => _username;
            set
            {
                if(_username != value)
                {
                    _username = value;
                    OnPropertyChanged(nameof(Username));
                }
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                if(_password != value)
                {
                    _password = value;
                    OnPropertyChanged(nameof(Password));
                }
            }
        }

        #endregion

        public LoginViewModel(IAuthenticationService authenticationService)
        {

            _authenticationService = authenticationService;

            LoginCommand = new ViewModelCommand(ExecuteLoginCommand);
            CreateAccountPageCommand = new ViewModelCommand(ExecuteCreateAccountPageCommand);
        }


        private void ExecuteLoginCommand(object parameter)
        {

            if (_authenticationService.UserExists(Username, Password))
            {
                MainWindow mainWindow = new MainWindow()
                {
                    WindowStartupLocation = WindowStartupLocation.CenterScreen
                };

                HideWindowAction?.Invoke();
                mainWindow.Show();
            }
            else
            {
                MessageBox.Show("No user");
            }
        }

        private void ExecuteCreateAccountPageCommand(object parameter)
        {
            CreateAccountWindow createAccountWindow = new CreateAccountWindow()
            {
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };

            HideWindowAction?.Invoke();
            createAccountWindow.Show();
        }
    }
}
