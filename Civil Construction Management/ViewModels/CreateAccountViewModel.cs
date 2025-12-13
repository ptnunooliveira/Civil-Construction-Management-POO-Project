using Civil_Construction_Management.Models;
using Civil_Construction_Management.ViewModels.Enums;
using Civil_Construction_Management.ViewModels.Interfaces;
using System.Windows;
using System.Windows.Input;

namespace Civil_Construction_Management.ViewModels
{
    /// <summary>
    /// ViewModel that manages all logic for the account creation screen.
    /// Handles input validation, account creation requests, and navigation
    /// to the login window.
    /// </summary>
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

        /// <summary>
        /// Delegate action used to close the currently active window. 
        /// Assigned by the View code-behind.
        /// </summary>
        public Action? HideWindowAction { get; set; }

        /// <summary>
        /// Command used to trigger the "Create Account" process.
        /// </summary>
        public ICommand CreateAccountCommand { get; }

        /// <summary>
        /// Command used to navigate to the Login window.
        /// </summary>
        public ICommand LoginPageCommand { get; }

        /// <summary>
        /// Username entered by the user during account creation.
        /// </summary>
        public string Username
        {
            get => _username;
            set
            {
                if (_username != value)
                {
                    _username = value;
                    OnPropertyChanged(nameof(Username));
                }
            }
        }

        /// <summary>
        /// Password chosen by the user.
        /// </summary>
        public string Password
        {
            get => _password;
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged(nameof(Password));
                }
            }
        }

        /// <summary>
        /// Confirmation password that must match the original password.
        /// </summary>
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

        /// <summary>
        /// Initializes the ViewModel with required services for authentication,
        /// messaging, and view navigation.
        /// </summary>
        /// <param name="authenticationService">Service responsible for user validation and creation.</param>
        /// <param name="messageService">Service used to display messages to the user.</param>
        /// <param name="viewFactory">Factory for window/view creation.</param>
        public CreateAccountViewModel(IAuthenticationService authenticationService, IMessageService messageService, IViewFactory viewFactory)
        {
            _authenticationService = authenticationService;
            _messageService = messageService;
            _viewFactory = viewFactory;

            // Initialize commands
            LoginPageCommand = new ViewModelCommand(ExecuteLoginPageCommand);
            CreateAccountCommand = new ViewModelCommand(ExecuteCreateAccountCommand);
        }

        #endregion


        #region Command Handlers

        /// <summary>
        /// Navigates back to the login window when triggered by the user.
        /// </summary>
        private void ExecuteLoginPageCommand(object parameter)
        {
            Window loginWindow = _viewFactory.CreateView(ViewType.Login);

            HideWindowAction?.Invoke(); // Hides current view
            loginWindow.Show();         // Opens login view
        }

        /// <summary>
        /// Validates input data and requests the authentication service to create a new user.
        /// Displays feedback messages and redirects to the login page upon success.
        /// </summary>
        private void ExecuteCreateAccountCommand(object parameter)
        {
            // Validate username availability
            if (_authenticationService.ValidUsername(Username))
            {
                _messageService.ShowMessage("Username is not valid.");
                return;
            }

            // Validate matching passwords
            if (_password != _passwordConfirmation)
            {
                _messageService.ShowMessage("The passwords must be the same.");
                return;
            }

            // Create user object
            var newUser = new User
            {
                Username = Username,
                Password = Password
            };

            // Attempt to create user
            if (!_authenticationService.CreateUser(newUser))
            {
                _messageService.ShowMessage("It was not possible to create a new user. Try again.");
                return;
            }

            _messageService.ShowMessage("Account created successfully.");

            // Navigate back to login window
            Window loginWindow = _viewFactory.CreateView(ViewType.Login);

            HideWindowAction?.Invoke();
            loginWindow.Show();
        }

        #endregion
    }
}