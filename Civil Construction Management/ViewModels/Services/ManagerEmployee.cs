using Civil_Construction_Management.Models;
using Civil_Construction_Management.Models.Repositories.Interfaces;
using Civil_Construction_Management.ViewModels.Interfaces;

namespace Civil_Construction_Management.ViewModels.Services
{
    /// <summary>
    /// Provides operations for creating, updating, deleting, and retrieving employees.
    /// Acts as a business-logic layer between the UI and the employee repository.
    /// </summary>
    public class ManagerEmployee : IManagerEmployee
    {
        private readonly IEmployeeRepository _employeeRepository;

        /// <summary>
        /// Initializes a new instance of <see cref="ManagerEmployee"/>.
        /// </summary>
        /// <param name="employeeRepository">The repository responsible for employee persistence.</param>
        public ManagerEmployee(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        /// <summary>
        /// Checks whether a given employee exists in the repository.
        /// </summary>
        /// <param name="e">The employee to verify.</param>
        /// <returns>True if the employee exists; otherwise false.</returns>
        /// <exception cref="ArgumentException">Thrown when the employee argument is null.</exception>
        public bool EmployeeExists(Employee e)
        {
            if (e == null)
                throw new ArgumentException("Invalid argument.");

            if (_employeeRepository.GetEmployeeByID(e.ID) == default)
                return false;

            return true;
        }

        /// <summary>
        /// Creates a new employee after validating all required fields.
        /// </summary>
        /// <param name="e">The employee to create.</param>
        /// <returns>
        /// True if the employee is valid and successfully stored;
        /// otherwise false.
        /// </returns>
        /// <exception cref="ArgumentException">Thrown when the employee argument is null.</exception>
        public bool CreateEmployee(Employee e)
        {
            if (e == null)
                throw new ArgumentException("Invalid argument.");

            // Field validation
            if (string.IsNullOrEmpty(e.Name)) return false;
            if (string.IsNullOrEmpty(e.NIF) || e.NIF.Length != 9) return false;
            if (string.IsNullOrEmpty(e.Email)) return false;
            if (string.IsNullOrEmpty(e.PhoneNumber) || e.PhoneNumber.Length != 9) return false;
            if (string.IsNullOrEmpty(e.Role)) return false;
            if (e.SalaryHour < 0) return false;

            // Prevent duplicates
            if (EmployeeExists(e)) return false;

            return _employeeRepository.AddEmployee(e);
        }

        /// <summary>
        /// Updates an existing employee with new information.
        /// </summary>
        /// <param name="updatedEmployee">The employee containing updated data.</param>
        /// <returns>
        /// True if update succeeds; otherwise false.
        /// </returns>
        public bool UpdateEmployee(Employee updatedEmployee)
        {
            if (updatedEmployee == null)
                return false;

            var employees = _employeeRepository.GetAllEmployees();

            var oldEmployee = employees.FirstOrDefault(e => e.ID == updatedEmployee.ID);
            if (oldEmployee == null)
                return false;

            // Update fields
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

        /// <summary>
        /// Deletes an employee from the system.
        /// </summary>
        /// <param name="e">The employee to delete.</param>
        /// <returns>
        /// True if deletion succeeds; otherwise false.
        /// </returns>
        /// <exception cref="ArgumentException">Thrown when the employee argument is null.</exception>
        public bool DeleteEmployee(Employee e)
        {
            if (e == null)
                throw new ArgumentException("Invalid argument.");

            if (!EmployeeExists(e))
                return false;

            return _employeeRepository.RemoveEmployee(e);
        }

        /// <summary>
        /// Retrieves all stored employees.
        /// </summary>
        /// <returns>A list of employees.</returns>
        public List<Employee> GetAllEmployees()
        {
            return _employeeRepository.GetAllEmployees();
        }
    }
}