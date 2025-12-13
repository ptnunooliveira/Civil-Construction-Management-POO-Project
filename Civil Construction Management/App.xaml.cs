using Civil_Construction_Management.Models.Repositories;
using Civil_Construction_Management.Models.Repositories.Interfaces;
using Civil_Construction_Management.ViewModels;
using Civil_Construction_Management.ViewModels.Interfaces;
using Civil_Construction_Management.ViewModels.Services;
using Civil_Construction_Management.Views.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace Civil_Construction_Management
{
    /// <summary>
    /// Interaction logic for App.xaml.
    /// This class initializes the application and sets up the dependency injection container.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// The static service provider used for dependency injection across the application.
        /// </summary>
        public static IServiceProvider ServiceProvider { get; private set; }

        /// <summary>
        /// Configures and builds the application's service provider,
        /// registering all view models, services, and repositories as singletons.
        /// </summary>
        private static void LoadServiceProvider()
        {
            ServiceProvider = new ServiceCollection()
                // ViewModels
                .AddSingleton<LoginViewModel>()
                .AddSingleton<CreateAccountViewModel>()
                .AddSingleton<MainWindowViewModel>()
                .AddSingleton<ListingEmployeeViewModel>()
                .AddSingleton<EmployeeViewModel>()
                .AddSingleton<MaterialViewModel>()
                .AddSingleton<ServiceViewModel>()
                .AddSingleton<ListingProjectViewModel>()
                .AddSingleton<ProjectViewModel>()

                // Repositories
                .AddSingleton<IUserRepository, UserRepository>()
                .AddSingleton<IEmployeeRepository, EmployeeRepository>()
                .AddSingleton<IProjectRepository, ProjectRepository>()

                // Services
                .AddSingleton<IAuthenticationService, AuthenticationService>()
                .AddSingleton<IManagerEmployee, ManagerEmployee>()
                .AddSingleton<IManagerProject, ManagerProject>()
                .AddSingleton<IMessageService, MessageService>()
                .AddSingleton<IViewFactory, ViewFactory>()

                .BuildServiceProvider();
        }

        /// <summary>
        /// Invoked when the application starts.
        /// Calls the method to load and configure the service provider for dependency injection.
        /// </summary>
        /// <param name="e">Startup event arguments.</param>
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            LoadServiceProvider();
        }
    }
}