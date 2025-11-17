using Civil_Construction_Management.ViewModel.Interfaces;
using System.Windows;
using System.Windows.Input;

namespace Civil_Construction_Management.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {

        #region Private Fields

        private IAuthenticationService _authenticationService;
        private ViewModelCommand _command;
        private string _username;
        private string _password;

        #endregion

        #region Public Properties
        public Action? HideWindowAction { get; set; }
        public ICommand LoginCommand { get; }

        public string Username
        {
            get => _username;
            set
            {
                if(_username != value)
                {
                    _username = value;
                    OnPropertyChanged(Username);
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
                    OnPropertyChanged(Password);
                }
            }
        }

        #endregion

        public LoginViewModel(IAuthenticationService authenticationService)
        {

            _authenticationService = authenticationService;
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand);
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
    }
}
