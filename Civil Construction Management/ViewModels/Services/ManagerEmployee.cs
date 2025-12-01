using Civil_Construction_Management.Models;
using Civil_Construction_Management.Models.Repositories.Interfaces;
using Civil_Construction_Management.ViewModels.Interfaces;

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

            if(string.IsNullOrEmpty(e.Name)) return false;
            if(string.IsNullOrEmpty(e.NIF) || e.NIF.Length != 9) return false;
            if(string.IsNullOrEmpty(e.Email)) return false;
            if(string.IsNullOrEmpty(e.PhoneNumber) || e.PhoneNumber.Length != 9) return false;
            if(string.IsNullOrEmpty(e.Role)) return false;
            if(e.SalaryHour < 0) return false;            
            if (EmployeeExists(e)) return false;

            return _employeeRepository.AddEmployee(e);
        }

        public bool UpdateEmployee(Employee updatedEmployee)
        {

            if (updatedEmployee == null)
                return false;

            var oldEmployee = _employeeRepository.GetEmployeeByNIF(updatedEmployee.NIF);
            if (oldEmployee == null)
                return false;

            var success = _employeeRepository.RemoveEmployee(oldEmployee);
            if (!success)
                return false;

            success = _employeeRepository.AddEmployee(updatedEmployee);
            if (!success)
                return false;

            return true;
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