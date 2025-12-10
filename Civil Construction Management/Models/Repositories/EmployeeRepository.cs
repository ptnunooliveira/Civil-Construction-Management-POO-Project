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

        public Employee GetEmployeeByID(int id)
        {

            //if ()
                //throw new ArgumentException("Invalid ID");
                        
            List<Employee> Employee = x.ReadJson<Employee>(_employeesFile);                        
            return Employee.FirstOrDefault(e => e.ID == id);
        }

        public bool AddEmployee(Employee e)
        {

            if (e == null)
                throw new ArgumentException("Invalid employee.");

            var employees = x.ReadJson<Employee>(_employeesFile);

            int newID = 1;
                        
            foreach(var emp in employees)
            {
                if (emp.ID >= newID)
                    newID = emp.ID + 1;
            }

            e.ID = newID;
            
            employees.Add(e);

            return x.WriteJson<Employee>(employees, _employeesFile);
        }

        public bool RemoveEmployee(Employee e)
        {

            if (e == null)
                throw new ArgumentException("Invalid employee.");

            List<Employee> _employees = x.ReadJson<Employee>(_employeesFile);

            
            var tmp = _employees.FirstOrDefault(n => n.ID == e.ID);
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

        public bool WriteEmployees(List<Employee> employees)
        {

            if (employees == null)
                return false;

            return x.WriteJson<Employee>(employees, _employeesFile);
        }
    }
}