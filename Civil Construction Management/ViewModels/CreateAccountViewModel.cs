using Civil_Construction_Management.Models;
using Civil_Construction_Management.ViewModels.Enums;
using Civil_Construction_Management.ViewModels.Interfaces;
using System.Windows;
using System.Windows.Input;

namespace Civil_Construction_Management.ViewModels
{
    public class CreateAccountViewModel : BaseViewModel
    {

        #region Private Fields
               
        private IAuthenticationService _authenticationService;
        private IMessageService _messageService;
        private IViewFactory _viewFactory;
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

        public CreateAccountViewModel(IAuthenticationService authenticationService, IMessageService messageService, IViewFactory viewFactory)
        {
            _authenticationService = authenticationService;
            _messageService = messageService;
            _viewFactory = viewFactory;

            LoginPageCommand = new ViewModelCommand(ExecuteLoginPageCommand);
            CreateAccountCommand = new ViewModelCommand(ExecuteCreateAccountCommand);
        }

        #endregion

        private void ExecuteLoginPageCommand(object parameter)
        {

            Window loginWindow = _viewFactory.CreateView(ViewType.Login);

            HideWindowAction?.Invoke();
            loginWindow.Show();
        }

        private void ExecuteCreateAccountCommand(object parameter)
        {

            if (_authenticationService.ValidUsername(Username))
            {
                _messageService.ShowMessage("Username is not valid.");
                return;
            }

            if (_password != _passwordConfirmation)
            {
                _messageService.ShowMessage("The passwords must be the same.");
                return;
            }

            var newUser = new User
            {
                Username = Username,
                Password = Password
            };

            
            if (!_authenticationService.CreateUser(newUser))
            {
                _messageService.ShowMessage("It was not possible to create a new user. Try again.");
                return;
            }

            _messageService.ShowMessage("Account created successfully.");

            Window loginWindow = _viewFactory.CreateView(ViewType.Login);

            HideWindowAction?.Invoke();
            loginWindow.Show();          
        }
    }
}
