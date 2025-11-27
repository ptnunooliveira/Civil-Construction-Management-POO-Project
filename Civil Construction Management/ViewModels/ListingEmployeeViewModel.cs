using Civil_Construction_Management.ViewModels.Interfaces;
using System.Collections.ObjectModel;

namespace Civil_Construction_Management.ViewModels
{
    public class ListingEmployeeViewModel : BaseViewModel
    {

        private readonly IManagerEmployee _managerEmployee;
        private readonly ObservableCollection<EmployeeViewModel> _employees;
        public ObservableCollection<EmployeeViewModel> Employees => _employees;

        public ListingEmployeeViewModel(IManagerEmployee managerEmployee)
        {

            _employees = new ObservableCollection<EmployeeViewModel>();
            _managerEmployee = managerEmployee;
        }

        public void LoadEmployees()
        {

            var employeeList = _managerEmployee.GetAllEmployees();

            foreach (var e in employeeList)
                _employees.Add(new EmployeeViewModel(e, _managerEmployee));
        }
    }
}