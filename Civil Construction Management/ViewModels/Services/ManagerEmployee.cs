using Civil_Construction_Management.Models;
using Civil_Construction_Management.Models.Repositories.Interfaces;
using Civil_Construction_Management.ViewModel.Interfaces;

namespace Civil_Construction_Management.ViewModels.Services
{
    public class ManagerEmployee : IManagerEmployee
    {

        private readonly IEmployeeRepository _employeeRepository;

        public ManagerEmployee(IEmployeeRepository employeeRepository)
        {

            _employeeRepository = employeeRepository;
        }

        public bool EmployeeExists(Employee e)
        {

            if (e == null)
                throw new ArgumentException("Invalid argument.");

            if (_employeeRepository.GetEmployeeByNIF(e.NIF) == default)
                return false;

            return true;
        }

        public bool CreateEmployee(Employee e)
        {

            if (e == null)
                throw new ArgumentException("Invalid argument.");

            if (EmployeeExists(e))
                return false;

            return _employeeRepository.AddEmployee(e);
        }

        public bool DeleteEmployee(Employee e)
        {

            if (e == null)
                throw new ArgumentException("Invalid argument.");

            if (!EmployeeExists(e))
                return false;

            return _employeeRepository.RemoveEmployee(e);
        }

        public List<Employee> GetAllEmployees()
        {

            return _employeeRepository.GetAllEmployees();
        }
    }
}