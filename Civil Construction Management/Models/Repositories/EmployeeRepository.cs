/// <summary>
/// EmployeeRepository is responsible for handling all data access operations related to employees.
/// 
/// This repository provides basic CRUD functionality.
/// </summary>
using Civil_Construction_Management.Exceptions;
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

            try
            {

                if (!Directory.Exists(_basePath))
                    Directory.CreateDirectory(_basePath);

                _employeesFile = Path.Combine(_basePath, "employees.json");

                if (!File.Exists(_employeesFile))
                    File.WriteAllText(_employeesFile, "[]");
            }

            catch(IOException ex)
            {
                throw new IOException("An error has occur trying to open the file.");
            }
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

            if (id < 1)
                return null;

            try
            {
                List<Employee> Employee = x.ReadJson<Employee>(_employeesFile);
                return Employee.FirstOrDefault(e => e.ID == id);
            }

            catch (Exception)
            {
                throw new DataAccessException("An error has occur accessing employee's data while trying to get an employee by id.");
            }
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
                return false;

            try
            {
                var employees = x.ReadJson<Employee>(_employeesFile);
                if (employees == null)
                    throw new DataAccessException("An error has occur accessing employee's data while trying to read the employee's file in order to add an employee.");

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

            catch (DataAccessException)
            {
                throw;
            }

            catch (Exception)
            {
                throw new DataAccessException("An error has occur accessing employee's data while trying to access employee's data to add an employee.");
            }
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
                return false;

            try
            {

                List<Employee> _employees = x.ReadJson<Employee>(_employeesFile);
                if (_employees == null)
                    throw new DataAccessException("An error has occur accessing employee's data while trying to read employee's data for delete.");

                var tmp = _employees.FirstOrDefault(n => n.ID == e.ID);
                if (tmp == null)
                    return false;

                if (_employees.Remove(tmp))
                    return x.WriteJson<Employee>(_employees, _employeesFile);

                return false;
            }

            catch(DataAccessException)
            {
                throw;
            }

            catch (Exception)
            {
                throw new DataAccessException("An error has occur accessing employee's data while trying to delete an employee.");
            }
        }

        /// <summary>
        /// Retrieves all employees stored in the repository.
        /// </summary>
        /// <returns>A list containing all Employee objects.</returns>
        public List<Employee> GetAllEmployees()
        {

            try
            {

                return x.ReadJson<Employee>(_employeesFile);
            }

            catch (Exception)
            {
                throw new DataAccessException("An error has occur accessing employee's data while trying to read from employee's file.");
            }
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

            try
            {

                return x.WriteJson<Employee>(employees, _employeesFile);
            }

            catch (Exception)
            {
                throw new DataAccessException("An error has occur accessing employee's data while trying to write on employee's file.");
            }
        }
    }
}
