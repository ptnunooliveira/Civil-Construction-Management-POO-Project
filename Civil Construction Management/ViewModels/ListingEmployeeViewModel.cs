using Civil_Construction_Management.Models;
using Civil_Construction_Management.ViewModels.Enums;
using Civil_Construction_Management.ViewModels.Interfaces;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Civil_Construction_Management.ViewModels
{
    /// <summary>
    /// ViewModel responsible for listing, creating, editing, deleting, and selecting employees.
    /// Also supports assigning employees to a project.
    /// </summary>
    public class ListingEmployeeViewModel : BaseViewModel
    {

        #region Private Fields

        /// <summary>
        /// Holds the currently selected employee in the UI list.
        /// </summary>
        private Employee _selectedObject;

        /// <summary>
        /// Service used to generate views dynamically.
        /// </summary>
        private IViewFactory _viewFactory;

        /// <summary>
        /// Service used for showing user messages.
        /// </summary>
        private IMessageService _messageService;

        /// <summary>
        /// Abstraction for managing employee data operations.
        /// </summary>
        private IManagerEmployee _managerEmployee;

        /// <summary>
        /// Internal collection of employees displayed in the UI.
        /// </summary>
        private ObservableCollection<Employee> _employees;

        /// <summary>
        /// Abstraction for managing project operations.
        /// </summary>
        private IManagerProject _managerProject;

        #endregion


        #region Public Properties

        /// <summary>
        /// Gets or sets the currently selected employee.
        /// </summary>
        public Employee SelectedObject
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
        /// Receives the project ID when selecting an employee for a project.
        /// </summary>
        public int ProjectID { get; set; }

        /// <summary>
        /// Action used to close the listing window.
        /// </summary>
        public Action HideWindowAction { get; set; }

        /// <summary>
        /// Command to add or select an employee (depending on context).
        /// </summary>
        public ICommand AddSelectEmployeeCommand { get; }

        /// <summary>
        /// Collection of employees displayed in the UI.
        /// </summary>
        public ObservableCollection<Employee> Employees => _employees;

        #endregion


        #region Constructor

        /// <summary>
        /// Initializes the ListingEmployeeViewModel with required dependencies.
        /// </summary>
        public ListingEmployeeViewModel(IManagerEmployee managerEmployee, IViewFactory viewFactory, IMessageService messageService, IManagerProject managerProject)
        {
            _employees = new ObservableCollection<Employee>();
            _managerEmployee = managerEmployee;
            _viewFactory = viewFactory;
            _messageService = messageService;
            _managerProject = managerProject;

            AddSelectEmployeeCommand = new ViewModelCommand(ExecuteAddSelectEmployee);

            LoadEmployees();
        }

        #endregion


        #region Methods


        #region Employees

        /// <summary>
        /// Loads all employees from the database into the observable collection.
        /// </summary>
        public void LoadEmployees()
        {
            _employees.Clear();

            var employeeList = _managerEmployee.GetAllEmployees();
            foreach (var e in employeeList)
                _employees.Add(e);
        }

        /// <summary>
        /// Opens the window for creating a new employee.
        /// </summary>
        public void ExecuteAddEmployeeWindowCommand(object parameter)
        {
            Window addEmployeeWindow = _viewFactory.CreateView(ViewType.AddEmployee);
            addEmployeeWindow.ShowDialog();

            _employees.Clear();
            LoadEmployees();
        }

        /// <summary>
        /// Opens the window for editing an existing employee.
        /// </summary>
        public void ExecuteEditEmployeeWindowCommand(object parameter)
        {
            if (parameter is not Employee e)
                return;

            var viewModel = new EmployeeViewModel(e, _managerEmployee);
            Window editEmployeeWindow = _viewFactory.CreateView(ViewType.AddEmployee);
            editEmployeeWindow.DataContext = viewModel;

            viewModel.HideWindowAction = () => editEmployeeWindow.Close();

            editEmployeeWindow.ShowDialog();

            _employees.Clear();
            LoadEmployees();
        }

        /// <summary>
        /// Deletes an employee after user confirmation.
        /// </summary>
        public void ExecuteDeleteEmployeeWindowCommand(object parameter)
        {
            if (parameter is not Employee e)
            {
                _messageService.ShowMessage("Employee not selected.");
                return;
            }

            MessageBoxResult confirmation = MessageBox.Show(
                $"Are you sure you want to delete {e.Name}?",
                "Confirm elimination?",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (confirmation == MessageBoxResult.Yes)
            {
                bool success = _managerEmployee.DeleteEmployee(e);
                if (success)
                {
                    _employees.Remove(e);
                    _messageService.ShowMessage("Employee removed successfully.");
                }
                else
                    _messageService.ShowMessage("Not possible.");
            }
            else
                return;
        }

        #endregion


        #region Project

        /// <summary>
        /// Assigns the selected employee to a project.
        /// </summary>
        private void ExecuteAddSelectEmployee(object parameter)
        {
            if (parameter is not Employee e)
                return;

            if (e.ProjectID != 0)
            {
                MessageBox.Show($"{e.Name} already belongs to a project.");
                return;
            }

            e.ProjectID = ProjectID;
            _managerEmployee.UpdateEmployee(e);

            bool success = _managerProject.AddEmployeeToProject(ProjectID, e);
            if (!success)
                return;

            HideWindowAction?.Invoke();
        }

        #endregion


        #endregion
    }
}