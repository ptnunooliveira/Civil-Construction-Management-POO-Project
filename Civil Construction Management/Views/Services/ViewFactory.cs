using Civil_Construction_Management.ViewModels.Enums;
using Civil_Construction_Management.ViewModels.Interfaces;
using System.Windows;

namespace Civil_Construction_Management.Views.Services
{
    public class ViewFactory : IViewFactory
    {
        public Window CreateView(ViewType type, object? parameter = null)
        {
            Window window = type switch
            {
                ViewType.Login => new LoginWindow(),
                ViewType.CreateAccount => new CreateAccountWindow(),
                ViewType.Main => new MainWindow(),

                _ => throw new NotImplementedException($"ViewFactory does not support view type {type}.")
            };

            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            return window;
        }
    }
}
