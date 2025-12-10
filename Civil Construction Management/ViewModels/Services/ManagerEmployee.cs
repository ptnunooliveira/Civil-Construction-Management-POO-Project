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

            if (_employeeRepository.GetEmployeeByID(e.ID) == default)
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

            var employees = _employeeRepository.GetAllEmployees();

            var oldEmployee = employees.FirstOrDefault<Employee>(e => e.ID == updatedEmployee.ID);
            if (oldEmployee == null)
                return false;

            oldEmployee.ProjectID = updatedEmployee.ProjectID;
            oldEmployee.Name = updatedEmployee.Name;
            oldEmployee.NIF = updatedEmployee.NIF;
            oldEmployee.PhoneNumber = updatedEmployee.PhoneNumber;
            oldEmployee.Email = updatedEmployee.Email;
            oldEmployee.Role = updatedEmployee.Role;
            oldEmployee.SalaryHour = updatedEmployee.SalaryHour;
            oldEmployee.StartDate = updatedEmployee.StartDate;

            return _employeeRepository.WriteEmployees(employees);
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