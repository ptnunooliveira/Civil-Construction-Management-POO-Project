using Civil_Construction_Management.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace Civil_Construction_Management.Views
{

    public partial class CreateAccountWindow : Window
    {

        private CreateAccountViewModel _createAccount;

        public CreateAccountWindow()
        {

            InitializeComponent();

            _createAccount = App.ServiceProvider.GetRequiredService<CreateAccountViewModel>();
            _createAccount.HideWindowAction = Hide;
            DataContext = _createAccount;
        }
    }
}
