using Civil_Construction_Management.ViewModels.Enums;
using Civil_Construction_Management.ViewModels.Interfaces;
using Civil_Construction_Management.Views;
using System.Windows;
using System.Windows.Input;

namespace Civil_Construction_Management.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {

        #region Private Fields

        private IAuthenticationService _authenticationService;
        private IMessageService _messageService;
        private IViewFactory _viewFactory;
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

        public LoginViewModel(IAuthenticationService authenticationService, IMessageService messageService, IViewFactory viewFactory)
        {

            _authenticationService = authenticationService;
            _messageService = messageService;
            _viewFactory = viewFactory;

            LoginCommand = new ViewModelCommand(ExecuteLoginCommand);
            CreateAccountPageCommand = new ViewModelCommand(ExecuteCreateAccountPageCommand);
        }


        private void ExecuteLoginCommand(object parameter)
        {

            if (_authenticationService.UserExists(Username, Password))
            {
                Window mainWindow = _viewFactory.CreateView(ViewType.Main);

                HideWindowAction?.Invoke();
                mainWindow.Show();
            }
            else
            {
                _messageService.ShowMessage("No user");
            }
        }

        private void ExecuteCreateAccountPageCommand(object parameter)
        {

            Window createAccountWindow = _viewFactory.CreateView(ViewType.CreateAccount);

            HideWindowAction?.Invoke();
            createAccountWindow.Show();
        }
    }
}
