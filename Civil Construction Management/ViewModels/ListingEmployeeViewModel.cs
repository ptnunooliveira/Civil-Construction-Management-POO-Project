using Civil_Construction_Management.Models;
using Civil_Construction_Management.ViewModels.Enums;
using Civil_Construction_Management.ViewModels.Interfaces;
using System.Collections.ObjectModel;
using System.Windows;

namespace Civil_Construction_Management.ViewModels
{
    public class ListingEmployeeViewModel : BaseViewModel
    {

        private IViewFactory _viewFactory;
        private readonly IManagerEmployee _managerEmployee;
        private readonly ObservableCollection<Employee> _employees;
        public ObservableCollection<Employee> Employees => _employees;

        public ListingEmployeeViewModel(IManagerEmployee managerEmployee, IViewFactory viewFactory)
        {

            _employees = new ObservableCollection<Employee>();
            _managerEmployee = managerEmployee;
            _viewFactory = viewFactory;

            LoadEmployees();
        }

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
    }
}