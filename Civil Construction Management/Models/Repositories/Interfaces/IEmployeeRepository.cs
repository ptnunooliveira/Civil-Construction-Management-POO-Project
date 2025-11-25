namespace Civil_Construction_Management.Models.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        
        public Employee GetEmployeeByNIF(string nif);
        public bool AddEmployee(Employee e);
        public bool RemoveEmployee(Employee e);
        public List<Employee> GetAllEmployees();
    }
}