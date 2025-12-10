using Civil_Construction_Management.Models;
using Civil_Construction_Management.ViewModels.Enums;
using Civil_Construction_Management.ViewModels.Interfaces;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Civil_Construction_Management.ViewModels
{
    public class ListingEmployeeViewModel : BaseViewModel
    {

        #region Private Fields
                
        private Employee _selectedObject;
        private IViewFactory _viewFactory;
        private IMessageService _messageService;
        private IManagerEmployee _managerEmployee;
        private ObservableCollection<Employee> _employees;
        private IManagerProject _managerProject;

        #endregion


        #region Public Properties
        public Employee SelectedObject
        {
            get => _selectedObject;
            set
            {
                if(_selectedObject != value)
                {

                    _selectedObject = value;
                    OnPropertyChanged(nameof(SelectedObject));
                }
            }
        }

        public int ProjectID{ get; set; }
        public Action HideWindowAction { get; set; }
        public ICommand AddSelectEmployeeCommand { get; }
        public ObservableCollection<Employee> Employees => _employees;

        #endregion


        #region Constructor
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

        public void LoadEmployees()
        {

            _employees.Clear();

            var employeeList = _managerEmployee.GetAllEmployees();
            foreach (var e in employeeList)
                _employees.Add(e);
        }
                
        public void ExecuteAddEmployeeWindowCommand(object parameter)
        {

            Window addEmployeeWindow = _viewFactory.CreateView(ViewType.AddEmployee);
            addEmployeeWindow.ShowDialog();

            _employees.Clear();
            LoadEmployees();
        }

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

        public void ExecuteDeleteEmployeeWindowCommand(object parameter)
        {

            if (parameter is not Employee e)
            {
                _messageService.ShowMessage("Employee not selected.");
                return;
            }

            MessageBoxResult confirmation = MessageBox.Show($"Are you sure you want to delete {e.Name}?",
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
        private void ExecuteAddSelectEmployee(object parameter)
        {

            if (parameter is not Employee e)
                return;

            if(e.ProjectID != 0)
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