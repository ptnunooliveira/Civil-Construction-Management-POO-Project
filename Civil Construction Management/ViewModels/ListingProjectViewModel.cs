using Civil_Construction_Management.Models;
using Civil_Construction_Management.ViewModels.Enums;
using Civil_Construction_Management.ViewModels.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Civil_Construction_Management.ViewModels
{
    /// <summary>
    /// ViewModel responsible for listing all projects and managing their related data:
    /// materials, services, and employees associated with each project.
    /// Provides commands for adding, editing, deleting, and selecting items.
    /// </summary>
    public class ListingProjectViewModel : BaseViewModel
    {

        #region Private Fields

        /// <summary>
        /// Internal collection containing all loaded projects.
        /// </summary>
        private ObservableCollection<Project> _projects;

        /// <summary>
        /// Service responsible for managing project-related data operations.
        /// </summary>
        private IManagerProject _managerProject;

        /// <summary>
        /// Service responsible for managing employee-related data operations.
        /// </summary>
        private IManagerEmployee _managerEmployee;

        /// <summary>
        /// Factory used for creating new views dynamically.
        /// </summary>
        private IViewFactory _viewFactory;

        /// <summary>
        /// Holds the currently selected project.
        /// </summary>
        private Project _selectedObject;

        /// <summary>
        /// Holds the selected material of the currently selected project.
        /// </summary>
        private Material _selectedMaterial;

        /// <summary>
        /// Holds the selected service of the currently selected project.
        /// </summary>
        private Service _selectedService;

        /// <summary>
        /// Holds the selected employee of the currently selected project.
        /// </summary>
        private Employee _selectedEmployee;

        #endregion


        #region Public Properties

        /// <summary>
        /// Gets or sets the currently selected project.
        /// </summary>
        public Project SelectedObject
        {
            get => _selectedObject;
            set
            {
                if (_selectedObject != value)
                {
                    _selectedObject = value;
                    OnPropertyChanged(nameof(SelectedObject));
                }
            }
        }

        /// <summary>
        /// Gets or sets the selected material.
        /// </summary>
        public Material SelectedMaterial
        {
            get => _selectedMaterial;
            set
            {
                if (_selectedMaterial != value)
                {
                    _selectedMaterial = value;
                    OnPropertyChanged(nameof(SelectedMaterial));
                }
            }
        }

        /// <summary>
        /// Gets or sets the selected service.
        /// </summary>
        public Service SelectedService
        {
            get => _selectedService;
            set
            {
                if (_selectedService != value)
                {
                    _selectedService = value;
                    OnPropertyChanged(nameof(SelectedService));
                }
            }
        }

        /// <summary>
        /// Gets or sets the selected employee.
        /// </summary>
        public Employee SelectedEmployee
        {
            get => _selectedEmployee;
            set
            {
                if (_selectedEmployee != value)
                {
                    _selectedEmployee = value;
                    OnPropertyChanged(nameof(SelectedEmployee));
                }
            }
        }

        /// <summary>
        /// Returns the list of all loaded projects.
        /// </summary>
        public ObservableCollection<Project> Projects => _projects;

        /// <summary>Command to add materials to a project.</summary>
        public ICommand AddMaterialCommand { get; }

        /// <summary>Command to delete a material from a project.</summary>
        public ICommand DeleteMaterialCommand { get; }

        /// <summary>Command to add services to a project.</summary>
        public ICommand AddServiceCommand { get; }

        /// <summary>Command to delete a service from a project.</summary>
        public ICommand DeleteServiceCommand { get; }

        /// <summary>Command to open the employee selection window.</summary>
        public ICommand SelectEmployeeCommand { get; }

        /// <summary>Command to remove an employee from a project.</summary>
        public ICommand DeleteEmployeeCommand { get; }

        #endregion


        #region Constructor

        /// <summary>
        /// Initializes the ListingProjectViewModel with required dependencies and loads projects.
        /// </summary>
        public ListingProjectViewModel(IViewFactory viewFactory, IManagerProject managerProject, IManagerEmployee managerEmployee)
        {
            _managerProject = managerProject;
            _managerEmployee = managerEmployee;
            _viewFactory = viewFactory;
            _projects = new ObservableCollection<Project>();

            AddMaterialCommand = new ViewModelCommand(ExecuteAddMaterialWindowCommand);
            DeleteMaterialCommand = new ViewModelCommand(ExecuteDeleteMaterialWindowCommand);
            AddServiceCommand = new ViewModelCommand(ExecuteAddServiceWindowCommand);
            DeleteServiceCommand = new ViewModelCommand(ExecuteDeleteServiceWindowCommand);
            SelectEmployeeCommand = new ViewModelCommand(ExecuteSelectEmployeeWindowCommand);
            DeleteEmployeeCommand = new ViewModelCommand(ExecuteDeleteEmployeeWindowCommand);

            LoadProjects();
        }

        #endregion


        #region Methods

        /// <summary>
        /// Loads all projects from the repository into the observable collection.
        /// </summary>
        private void LoadProjects()
        {
            var proj = _managerProject.LoadProjects();
            foreach (Project p in proj)
            {
                _projects.Add(p);
            }
        }


        #region Project

        /// <summary>
        /// Opens the window to create a new project.
        /// </summary>
        public void ExecuteAddProjectWindowCommand(object parameter)
        {
            Window addProjectWindow = _viewFactory.CreateView(ViewType.AddProject);
            addProjectWindow.ShowDialog();

            _projects.Clear();
            LoadProjects();
        }

        /// <summary>
        /// Opens the window to edit the selected project.
        /// </summary>
        public void ExecuteEditProjectWindowCommand(object parameter)
        {
            var viewModel = new ProjectViewModel(_selectedObject, _managerProject);

            Window editProjectWindow = _viewFactory.CreateView(ViewType.AddProject);
            editProjectWindow.DataContext = viewModel;

            viewModel.HideWindowAction = () => editProjectWindow.Hide();

            editProjectWindow.ShowDialog();

            _projects.Clear();
            LoadProjects();
        }

        /// <summary>
        /// Deletes the selected project after user confirmation.
        /// </summary>
        public void ExecuteDeleteProjectWindowCommand(object parameter)
        {
            if (parameter is not Project proj)
                return;

            MessageBoxResult confirmation = MessageBox.Show(
                $"Are you sure you want to delete the project with ID: {proj.ID}?",
                "Confirm elimination?",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (confirmation == MessageBoxResult.Yes)
            {
                bool success = _managerProject.DeleteProject(proj);
                if (success)
                {
                    _projects.Remove(proj);
                    MessageBox.Show("Project removed successfully.");
                }
                else
                    MessageBox.Show("Not possible.");
            }
        }

        #endregion


        #region Material

        /// <summary>
        /// Opens the window to add a material to a project.
        /// </summary>
        public void ExecuteAddMaterialWindowCommand(object parameter)
        {
            if (parameter is not Project p)
                return;

            var viewModel = App.ServiceProvider.GetRequiredService<MaterialViewModel>();
            viewModel.ProjectID = p.ID;

            Window addMaterialWindow = _viewFactory.CreateView(ViewType.AddMaterial);
            addMaterialWindow.DataContext = viewModel;

            viewModel.HideWindowAction = () => addMaterialWindow.Hide();

            addMaterialWindow.ShowDialog();

            _projects.Clear();
            LoadProjects();
        }

        /// <summary>
        /// Deletes the selected material after user confirmation.
        /// </summary>
        public void ExecuteDeleteMaterialWindowCommand(object parameter)
        {
            if (parameter is not Material material)
                return;

            MessageBoxResult confirmation = MessageBox.Show(
                $"Are you sure you want to delete {material.Name}?",
                "Confirm elimination?",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (confirmation == MessageBoxResult.Yes)
            {
                bool success = _managerProject.DeleteMaterial(material);
                if (success)
                {
                    MessageBox.Show($"{material.Name} removed successfully.");
                    _projects.Clear();
                    LoadProjects();
                }
                else
                    MessageBox.Show("Not possible.");
            }
        }

        #endregion


        #region Services

        /// <summary>
        /// Opens the window to add a service to a project.
        /// </summary>
        public void ExecuteAddServiceWindowCommand(object parameter)
        {
            if (parameter is not Project project)
                return;

            var viewModel = App.ServiceProvider.GetRequiredService<ServiceViewModel>();
            viewModel.ProjectID = project.ID;

            Window addServiceWindow = _viewFactory.CreateView(ViewType.AddService);
            addServiceWindow.DataContext = viewModel;

            viewModel.HideWindowAction = () => addServiceWindow.Hide();

            addServiceWindow.ShowDialog();

            _projects.Clear();
            LoadProjects();
        }

        /// <summary>
        /// Deletes the selected service after user confirmation.
        /// </summary>
        public void ExecuteDeleteServiceWindowCommand(object parameter)
        {
            if (parameter is not Service service)
                return;

            MessageBoxResult confirmation = MessageBox.Show(
                $"Are you sure you want to delete {service.CompanyName}'s service?",
                "Confirm elimination?",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (confirmation == MessageBoxResult.Yes)
            {
                bool success = _managerProject.DeleteService(service);
                if (success)
                {
                    MessageBox.Show($"{service.CompanyName}'s service removed successfully.");
                    _projects.Clear();
                    LoadProjects();
                }
                else
                    MessageBox.Show("Not possible.");
            }
        }

        #endregion


        #region Employees

        /// <summary>
        /// Opens the employee selection window to add employees to a project.
        /// </summary>
        private void ExecuteSelectEmployeeWindowCommand(object parameter)
        {
            if (parameter is not Project project)
                return;

            var viewModel = App.ServiceProvider.GetRequiredService<ListingEmployeeViewModel>();
            viewModel.ProjectID = project.ID;
            viewModel.LoadEmployees();

            Window selectEmployeeWindow = _viewFactory.CreateView(ViewType.SelectEmployee);
            selectEmployeeWindow.DataContext = viewModel;

            viewModel.HideWindowAction = () => selectEmployeeWindow.Close();

            selectEmployeeWindow.ShowDialog();

            _projects.Clear();
            LoadProjects();
        }

        /// <summary>
        /// Removes an employee from a project after confirmation.
        /// </summary>
        public void ExecuteDeleteEmployeeWindowCommand(object parameter)
        {
            if (parameter is not Employee employee)
                return;

            MessageBoxResult confirmation = MessageBox.Show(
                $"Are you sure you want to delete {employee.Name}?",
                "Confirm elimination?",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (confirmation == MessageBoxResult.Yes)
            {
                bool success = _managerProject.DeleteEmployee(employee);
                if (success)
                {
                    employee.ProjectID = 0;
                    _managerEmployee.UpdateEmployee(employee);

                    MessageBox.Show($"{employee.Name} removed successfully.");

                    _projects.Clear();
                    LoadProjects();
                }
                else
                    MessageBox.Show("Not possible.");
            }
        }

        #endregion

        #endregion
    }
}