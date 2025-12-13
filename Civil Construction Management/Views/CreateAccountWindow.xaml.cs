using Civil_Construction_Management.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace Civil_Construction_Management.Views
{
    /// <summary>
    /// Interaction logic for CreateAccountWindow.xaml.
    /// This window allows the user to create a new account.
    /// </summary>
    public partial class CreateAccountWindow : Window
    {
        private CreateAccountViewModel _createAccount;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateAccountWindow"/> class.
        /// Resolves the <see cref="CreateAccountViewModel"/> via dependency injection,
        /// assigns it as the DataContext, and registers the window hide action.
        /// </summary>
        public CreateAccountWindow()
        {
            InitializeComponent();

            // Resolve the ViewModel instance from the dependency injection container
            _createAccount = App.ServiceProvider.GetRequiredService<CreateAccountViewModel>();

            // Allow the ViewModel to hide this window programmatically
            _createAccount.HideWindowAction = Hide;

            // Set the ViewModel as the DataContext for data binding
            DataContext = _createAccount;
        }
    }
}