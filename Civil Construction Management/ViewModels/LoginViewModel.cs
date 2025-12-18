using Civil_Construction_Management.Exceptions;
using Civil_Construction_Management.ViewModels.Enums;
using Civil_Construction_Management.ViewModels.Interfaces;
using System.Windows;
using System.Windows.Input;

namespace Civil_Construction_Management.ViewModels
{
    /// <summary>
    /// ViewModel responsible for handling user login logic.
    /// Includes authentication, navigation to account creation,
    /// and switching between views based on login success.
    /// </summary>
    public class LoginViewModel : BaseViewModel
    {

        #region Private Fields

        /// <summary>
        /// Service responsible for user authentication operations.
        /// </summary>
        private IAuthenticationService _authenticationService;

        /// <summary>
        /// Service for displaying messages to the user.
        /// </summary>
        private IMessageService _messageService;

        /// <summary>
        /// Factory used to create different application windows.
        /// </summary>
        private IViewFactory _viewFactory;

        /// <summary>
        /// Stores the username entered by the user.
        /// </summary>
        private string _username;

        /// <summary>
        /// Stores the password entered by the user.
        /// </summary>
        private string _password;

        #endregion


        #region Public Properties

        /// <summary>
        /// Action used to request the current view to close or hide itself.
        /// Usually assigned in the View's code-behind.
        /// </summary>
        public Action? HideWindowAction { get; set; }

        /// <summary>
        /// Command triggered when the user clicks the Login button.
        /// </summary>
        public ICommand LoginCommand { get; }

        /// <summary>
        /// Command triggered when the user navigates to the Create Account page.
        /// </summary>
        public ICommand CreateAccountPageCommand { get; }

        /// <summary>
        /// Username entered by the user.
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
        /// Password entered by the user.
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

        #endregion


        #region Constructor
        /// <summary>
        /// Initializes a new instance of the LoginViewModel with necessary services
        /// and sets up the available commands.
        /// </summary>
        public LoginViewModel(IAuthenticationService authenticationService, IMessageService messageService, IViewFactory viewFactory)
        {
            _authenticationService = authenticationService;
            _messageService = messageService;
            _viewFactory = viewFactory;

            LoginCommand = new ViewModelCommand(ExecuteLoginCommand);
            CreateAccountPageCommand = new ViewModelCommand(ExecuteCreateAccountPageCommand);
        }


        #endregion


        #region Methods

        /// <summary>
        /// Attempts to log the user in using the provided credentials.
        /// If successful, opens the Main window.
        /// If unsuccessful, displays an error message.
        /// </summary>
        private void ExecuteLoginCommand(object parameter)
        {

            try
            {

                bool success = _authenticationService.UserExists(Username, Password);
                if (success)
                {

                    Window mainWindow = _viewFactory.CreateView(ViewType.Main);

                    HideWindowAction?.Invoke();
                    mainWindow.Show();
                }
            }

            catch (ArgumentException ex)
            {

                MessageBox.Show(ex.Message, "WARNING", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            catch (DataAccessException ex)
            {

                MessageBox.Show(ex.Message, "WARNING", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Opens the Create Account window and hides the current login window.
        /// </summary>
        private void ExecuteCreateAccountPageCommand(object parameter)
        {
            Window createAccountWindow = _viewFactory.CreateView(ViewType.CreateAccount);

            HideWindowAction?.Invoke();
            createAccountWindow.Show();
        }
    }

    #endregion

}