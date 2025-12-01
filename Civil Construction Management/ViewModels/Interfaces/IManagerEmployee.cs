using Civil_Construction_Management.Models;

namespace Civil_Construction_Management.ViewModels.Interfaces
{
    public interface IManagerEmployee
    {
        public bool CreateEmployee(Employee e);
        public bool EmployeeExists(Employee e);
        public bool DeleteEmployee(Employee e);
        public bool UpdateEmployee(Employee updatedEmployee);
        public List<Employee> GetAllEmployees();
    }
}