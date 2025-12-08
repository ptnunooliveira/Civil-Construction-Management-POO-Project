namespace Civil_Construction_Management.Models.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        
        public Employee GetEmployeeByID(int id);
        public bool AddEmployee(Employee e);
        public bool RemoveEmployee(Employee e);
        public List<Employee> GetAllEmployees();
        public bool WriteEmployees(List<Employee> employees);
    }
}