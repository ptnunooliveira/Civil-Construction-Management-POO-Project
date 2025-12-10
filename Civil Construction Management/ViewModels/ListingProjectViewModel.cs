using Civil_Construction_Management.Models;
using Civil_Construction_Management.ViewModels.Enums;
using Civil_Construction_Management.ViewModels.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Civil_Construction_Management.ViewModels
{
    public class ListingProjectViewModel : BaseViewModel
    {

        #region Private Fields

        private ObservableCollection<Project> _projects;
        private IManagerProject _managerProject;
        private IManagerEmployee _managerEmployee;
        private IViewFactory _viewFactory;
        private Project _selectedObject;
        private Material _selectedMaterial;
        private Service _selectedService;
        private Employee _selectedEmployee;

        #endregion


        #region Public Properties
                
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

        public Service SelectedService
        {
            get => _selectedService;
            set
            {
                if(_selectedService != value)
                {
                    _selectedService = value;
                    OnPropertyChanged(nameof(SelectedService));
                }
            }
        }

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

        public ObservableCollection<Project> Projects => _projects;

        public ICommand AddMaterialCommand { get; }
        public ICommand DeleteMaterialCommand { get; }
        public ICommand AddServiceCommand { get; }
        public ICommand DeleteServiceCommand { get; }
        public ICommand SelectEmployeeCommand { get; }
        public ICommand DeleteEmployeeCommand { get; }

        #endregion


        #region Constructor

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

        private void LoadProjects()
        {

            var proj = _managerProject.LoadProjects();
            foreach (Project p in proj)
            {
                _projects.Add(p);
            }
        }

        #region Project

        public void ExecuteAddProjectWindowCommand(object parameter)
        {

            Window addProjectWindow = _viewFactory.CreateView(ViewType.AddProject);
            addProjectWindow.ShowDialog();

            _projects.Clear();
            LoadProjects();
        }

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

        public void ExecuteDeleteProjectWindowCommand(object parameter)
        {

            if (parameter is not Project proj)
                return;

            MessageBoxResult confirmation = MessageBox.Show($"Are you sure you want to delete the project with ID: {proj.ID}?",
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
            else
                return;
        }

        #endregion


        #region Material

        public void ExecuteAddMaterialWindowCommand(object parameter)
        {

            if (parameter is not Project p)
            {
                return;
                throw new ArgumentNullException("Object not selected");
            }

            var viewModel = App.ServiceProvider.GetRequiredService<MaterialViewModel>();
            viewModel.ProjectID = p.ID; // MaterialViewModel gets the ProjectID

            Window addMaterialWindow = _viewFactory.CreateView(ViewType.AddMaterial);
            addMaterialWindow.DataContext = viewModel;

            viewModel.HideWindowAction = () => addMaterialWindow.Hide();

            addMaterialWindow.ShowDialog();            

            _projects.Clear();
            LoadProjects();
        }

        public void ExecuteDeleteMaterialWindowCommand(object parameter)
        {

            if (parameter is not Material material)
                return;

            MessageBoxResult confirmation = MessageBox.Show($"Are you sure you want to delete {material.Name}?",
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
            else
                return;
        }

        #endregion


        #region Services

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

        public void ExecuteDeleteServiceWindowCommand(object parameter)
        {

            if (parameter is not Service service)
                return;

            MessageBoxResult confirmation = MessageBox.Show($"Are you sure you want to delete {service.CompanyName}'s service?",
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
            else
                return;
        }

        #endregion


        #region Employees

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

        public void ExecuteDeleteEmployeeWindowCommand(object parameter)
        {

            if (parameter is not Employee employee)
                return;

            MessageBoxResult confirmation = MessageBox.Show($"Are you sure you want to delete {employee.Name}?",
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
            else
                return;
        }

        #endregion

        #endregion

    }
}
