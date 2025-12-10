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
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public static IServiceProvider ServiceProvider { get; private set; }

        private static void LoadServiceProvider()
        {
            ServiceProvider = new ServiceCollection()
                .AddSingleton<LoginViewModel>()
                .AddSingleton<CreateAccountViewModel>()
                .AddSingleton<MainWindowViewModel>()
                .AddSingleton<ListingEmployeeViewModel>()
                .AddSingleton<EmployeeViewModel>()
                .AddSingleton<MaterialViewModel>()
                .AddSingleton<ServiceViewModel>()
                .AddSingleton<ListingProjectViewModel>()
                .AddSingleton<ProjectViewModel>()
                .AddSingleton<IUserRepository, UserRepository>()
                .AddSingleton<IAuthenticationService, AuthenticationService>()
                .AddSingleton<IEmployeeRepository, EmployeeRepository>()
                .AddSingleton<IManagerEmployee, ManagerEmployee>()
                .AddSingleton<IMessageService, MessageService>()
                .AddSingleton<IViewFactory, ViewFactory>()
                .AddSingleton<IManagerProject, ManagerProject>()
                .AddSingleton<IProjectRepository, ProjectRepository>()
                .BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            LoadServiceProvider();
        }
    }

}
