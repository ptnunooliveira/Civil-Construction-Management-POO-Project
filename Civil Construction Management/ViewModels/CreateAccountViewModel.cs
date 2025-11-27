using Civil_Construction_Management.Models;
using Civil_Construction_Management.ViewModels.Interfaces;
using Civil_Construction_Management.Views;
using System.Windows;
using System.Windows.Input;

namespace Civil_Construction_Management.ViewModels
{
    public class CreateAccountViewModel : BaseViewModel
    {

        #region Private Fields

        private IAuthenticationService _authenticationService;
        private string _username;
        private string _password;
        private string _passwordConfirmation;

        #endregion


        #region Public Properties
        public Action? HideWindowAction { get; set; }
        public ICommand CreateAccountCommand { get; }
        public ICommand LoginPageCommand { get; }

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

        public string PasswordConfirmation
        {
            get => _passwordConfirmation;
            set
            {
                if (_passwordConfirmation != value)
                {
                    _passwordConfirmation = value;
                    OnPropertyChanged(nameof(PasswordConfirmation));
                }
            }
        }

        #endregion

        #region Constructor

        public CreateAccountViewModel(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;

            LoginPageCommand = new ViewModelCommand(ExecuteLoginPageCommand);
            CreateAccountCommand = new ViewModelCommand(ExecuteCreateAccountCommand);
        }

        #endregion

        private void ExecuteLoginPageCommand(object parameter)
        {

            LoginWindow loginWindow = new LoginWindow()
            {
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };

            HideWindowAction?.Invoke();
            loginWindow.Show();
        }

        private void ExecuteCreateAccountCommand(object parameter)
        {

            if (_authenticationService.ValidUsername(Username))
            {
                MessageBox.Show("Username is not valid.");
                return;
            }

            if (_password != _passwordConfirmation)
            {
                MessageBox.Show("The passwords must be the same.");
                return;
            }

            var newUser = new User
            {
                Username = Username,
                Password = Password
            };


            MessageBox.Show("Account created successfully.");

            if (!_authenticationService.CreateUser(newUser))
            {
                MessageBox.Show("It was not possible to create a new user. Try again.");
                return;
            }

            LoginWindow loginWindow = new LoginWindow()
            {
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };

            HideWindowAction?.Invoke();
            loginWindow.Show();          
        }
    }
}
