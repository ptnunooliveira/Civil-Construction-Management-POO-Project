using Civil_Construction_Management.Models.Repositories.Interfaces;
using DLL___Project_Support;
using System.IO;

namespace Civil_Construction_Management.Models.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly string _employeesFile;
        private string _basePath = Path.Combine("." + Path.DirectorySeparatorChar, "Data");

        private readonly VerifyRepositories x = new VerifyRepositories();

        public EmployeeRepository()
        {

            if (!Directory.Exists(_basePath))
                Directory.CreateDirectory(_basePath);

            _employeesFile = Path.Combine(_basePath, "employees.json");

            if (!File.Exists(_employeesFile))
                File.WriteAllText(_employeesFile, "[]");                        
        }

        public Employee GetEmployeeByNIF(string nif)
        {

            if (nif == null || nif.Length != 9)
                throw new ArgumentException("Invalid NIF.");
                        
            List<Employee> Employee = x.ReadJson<Employee>(_employeesFile);                        
            return Employee.FirstOrDefault(e => e.NIF == nif);
        }

        public bool AddEmployee(Employee e)
        {

            if (e == null)
                throw new ArgumentException("Invalid employee.");
            
            return x.AppendJson<Employee>(e, _employeesFile);
        }

        public bool RemoveEmployee(Employee e)
        {

            if (e == null)
                throw new ArgumentException("Invalid employee.");

            List<Employee> _employees = x.ReadJson<Employee>(_employeesFile);

            
            var tmp = _employees.FirstOrDefault(n => n.NIF == e.NIF);
            if (tmp == null)
                return false;

            if (_employees.Remove(tmp))
                return x.WriteJson<Employee>(_employees, _employeesFile);

            return false;
        }

        public List<Employee> GetAllEmployees()
        {

            return x.ReadJson<Employee>(_employeesFile);
        }
    }
}