using Civil_Construction_Management.Models;
using Civil_Construction_Management.ViewModels.Enums;
using Civil_Construction_Management.ViewModels.Interfaces;
using System.Collections.ObjectModel;
using System.Windows;

namespace Civil_Construction_Management.ViewModels
{
    public class ListingEmployeeViewModel : BaseViewModel
    {

        #region Private Fields

        private Employee _selectedEmployee;
        private IViewFactory _viewFactory;
        private IMessageService _messageService;
        private readonly IManagerEmployee _managerEmployee;
        private readonly ObservableCollection<Employee> _employees;

        #endregion


        #region Public Properties
        public Employee SelectedEmployee
        {
            get => _selectedEmployee;
            set
            {
                if(_selectedEmployee != value)
                {

                    _selectedEmployee = value;
                    OnPropertyChanged(nameof(SelectedEmployee));
                }
            }
        }

        public ObservableCollection<Employee> Employees => _employees;

        #endregion


        #region Constructor
        public ListingEmployeeViewModel(IManagerEmployee managerEmployee, IViewFactory viewFactory, IMessageService messageService)
        {

            _employees = new ObservableCollection<Employee>();
            _managerEmployee = managerEmployee;
            _viewFactory = viewFactory;
            _messageService = messageService; 

            LoadEmployees();
        }

        #endregion


        #region Methods

        public void LoadEmployees()
        {

            var employeeList = _managerEmployee.GetAllEmployees();
            foreach (var e in employeeList)
                _employees.Add(e);
        }

        public void ExecuteAddEmployeeWindowCommand(object parameter)
        {

            Window addEmployeeWindow = _viewFactory.CreateView(ViewType.AddEmployee);
            addEmployeeWindow.Show();
        }

        public void ExecuteEditEmployeeWindowCommand(object parameter)
        {

            if (parameter is not Employee e)
                return;

            var viewModel = new EmployeeViewModel(e, _managerEmployee);
            Window editEmployeeWindow = _viewFactory.CreateView(ViewType.AddEmployee);
            editEmployeeWindow.DataContext = viewModel;
            editEmployeeWindow.Show();
            viewModel.HideWindowAction = () => editEmployeeWindow.Close();
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
    }
}