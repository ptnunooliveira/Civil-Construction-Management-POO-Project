using Civil_Construction_Management.ViewModels.Enums;
using Civil_Construction_Management.ViewModels.Interfaces;
using System.Windows;

namespace Civil_Construction_Management.Views.Services
{
    /// <summary>
    /// A factory responsible for creating WPF Window instances based on the specified ViewType.
    /// This centralizes view creation and avoids direct view dependencies inside ViewModels.
    /// </summary>
    public class ViewFactory : IViewFactory
    {
        /// <summary>
        /// Creates and returns a Window corresponding to the supplied <see cref="ViewType"/>.
        /// Optionally receives a parameter if the view requires initialization data.
        /// </summary>
        /// <param name="type">The type of view/window to be created.</param>
        /// <param name="parameter">Optional parameter that may be passed to the window during creation.</param>
        /// <returns>A fully constructed WPF Window instance.</returns>
        /// <exception cref="NotImplementedException">
        /// Thrown when the factory does not recognize the provided ViewType.
        /// </exception>
        public Window CreateView(ViewType type, object? parameter = null)
        {
            // Selects the window type based on the given ViewType.
            // If the type is not supported, an exception is thrown.
            Window window = type switch
            {
                ViewType.Login => new LoginWindow(),
                ViewType.CreateAccount => new CreateAccountWindow(),
                ViewType.Main => new MainWindow(),
                ViewType.AddEmployee => new AddEmployeeWindow(),
                ViewType.AddProject => new AddProjectWindow(),
                ViewType.AddMaterial => new AddMaterialWindow(),
                ViewType.AddService => new AddServiceWindow(),
                ViewType.SelectEmployee => new SelectEmployeeWindow(),

                _ => throw new NotImplementedException(
                        $"ViewFactory does not support view type {type}.")
            };

            // Ensures that all windows open centered on the screen for consistent UI behavior.
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            return window;
        }
    }
}
