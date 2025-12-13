using Civil_Construction_Management.Models.Repositories.Interfaces;
using DLL___Project_Support;
using System.IO;

namespace Civil_Construction_Management.Models.Repositories
{
    /// <summary>
    /// Repository responsible for handling CRUD operations related to employees.
    /// Data is persisted in a JSON file located in the Data directory.
    /// </summary>
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly string _employeesFile;
        private string _basePath = Path.Combine("." + Path.DirectorySeparatorChar, "Data");

        private readonly VerifyRepositories x = new VerifyRepositories();

        /// <summary>
        /// Initializes the repository, ensures the Data directory exists, 
        /// and creates the employees.json file if it does not already exist.
        /// </summary>
        public EmployeeRepository()
        {

            if (!Directory.Exists(_basePath))
                Directory.CreateDirectory(_basePath);

            _employeesFile = Path.Combine(_basePath, "employees.json");

            if (!File.Exists(_employeesFile))
                File.WriteAllText(_employeesFile, "[]");
        }

        /// <summary>
        /// Retrieves an employee based on their ID.
        /// </summary>
        /// <param name="id">The unique identifier of the employee.</param>
        /// <returns>
        /// The corresponding Employee object, or null if no employee 
        /// with the specified ID exists.
        /// </returns>
        public Employee GetEmployeeByID(int id)
        {

            //if ()
            //throw new ArgumentException("Invalid ID");

            List<Employee> Employee = x.ReadJson<Employee>(_employeesFile);
            return Employee.FirstOrDefault(e => e.ID == id);
        }

        /// <summary>
        /// Adds a new employee to the repository. 
        /// Automatically assigns a unique incremental ID.
        /// </summary>
        /// <param name="e">The Employee object to add.</param>
        /// <returns>True if the employee was successfully added; otherwise, False.</returns>
        public bool AddEmployee(Employee e)
        {

            if (e == null)
                throw new ArgumentException("Invalid employee.");

            var employees = x.ReadJson<Employee>(_employeesFile);

            int newID = 1;

            foreach (var emp in employees)
            {
                if (emp.ID >= newID)
                    newID = emp.ID + 1;
            }

            e.ID = newID;

            employees.Add(e);

            return x.WriteJson<Employee>(employees, _employeesFile);
        }

        /// <summary>
        /// Removes an employee from the repository.
        /// </summary>
        /// <param name="e">The Employee object to remove.</param>
        /// <returns>
        /// True if the employee was successfully removed and saved; 
        /// otherwise, False.
        /// </returns>
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

        /// <summary>
        /// Retrieves all employees stored in the repository.
        /// </summary>
        /// <returns>A list containing all Employee objects.</returns>
        public List<Employee> GetAllEmployees()
        {

            return x.ReadJson<Employee>(_employeesFile);
        }

        /// <summary>
        /// Writes the provided employee list to storage, overwriting previous data.
        /// </summary>
        /// <param name="employees">The list of employees to write.</param>
        /// <returns>True if writing was successful; otherwise, False.</returns>
        public bool WriteEmployees(List<Employee> employees)
        {

            if (employees == null)
                return false;

            return x.WriteJson<Employee>(employees, _employeesFile);
        }
    }
}
