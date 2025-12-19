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


        #region Constructor

        /// <summary>
        /// Initializes a new instance of <see cref="ManagerEmployee"/>.
        /// </summary>
        /// <param name="employeeRepository">The repository responsible for employee persistence.</param>
        public ManagerEmployee(IEmployeeRepository employeeRepository)
        {

            _employeeRepository = employeeRepository;
        }

        #endregion


        #region Methods

        /// <summary>
        /// Checks whether a given employee exists in the repository.
        /// </summary>
        /// <param name="e">The employee to verify.</param>
        /// <returns>True if the employee exists; otherwise false.</returns>
        public bool EmployeeExists(Employee e)
        {

            if (e == null)
                throw new ArgumentException("Employee can't be null");
                        
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
        public bool CreateEmployee(Employee e)
        {
            if (e == null)
                return false;

            // Field validation
            if (string.IsNullOrEmpty(e.Name))
                throw new ArgumentException("Employee's Name can't be null");

            if (e.Name.Length > 50)
                throw new ArgumentException("Employee's Name is too long. Must be 50 characters or less");

            if (string.IsNullOrEmpty(e.NIF))
                throw new ArgumentException("Employee's NIF can't be null");

            if (e.NIF.Length != 9)
                throw new ArgumentException("Employee's NIF must be 9 characters long");

            if (string.IsNullOrEmpty(e.Email))
                throw new ArgumentException("Employee's email can't be null");

            if (e.Email.Length > 50)
                throw new ArgumentException("Employee's email is too long. Must be 50 characters or less");

            if (!e.Email.Contains('@'))
                throw new ArgumentException("Check employee's email format");

            if (string.IsNullOrEmpty(e.PhoneNumber))
                throw new ArgumentException("Employee's contact can't be null");

            if (e.PhoneNumber.Length != 9)
                throw new ArgumentException("Employee's contact must be 9 characters long");

            if (string.IsNullOrEmpty(e.Role))
                throw new ArgumentException("Employee's role can't be null");

            if (e.SalaryHour < 5.75)
                throw new ArgumentException("Employee's salary must be at least the minimum wage");

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

            if (string.IsNullOrEmpty(updatedEmployee.Name))
                throw new ArgumentException("Employee's Name can't be null");

            if (updatedEmployee.Name.Length > 50)
                throw new ArgumentException("Employee's Name is too long. Must be 50 characters or less");

            if (string.IsNullOrEmpty(updatedEmployee.NIF))
                throw new ArgumentException("Employee's NIF can't be null");

            if (updatedEmployee.NIF.Length != 9)
                throw new ArgumentException("Employee's NIF must be 9 characters long");

            if (string.IsNullOrEmpty(updatedEmployee.Email))
                throw new ArgumentException("Employee's email can't be null");

            if (updatedEmployee.Email.Length > 50)
                throw new ArgumentException("Employee's email is too long. Must be 50 characters or less");

            if (!updatedEmployee.Email.Contains('@'))
                throw new ArgumentException("Check employee's email format");

            if (string.IsNullOrEmpty(updatedEmployee.PhoneNumber))
                throw new ArgumentException("Employee's contact can't be null");

            if (updatedEmployee.PhoneNumber.Length != 9)
                throw new ArgumentException("Employee's contact must be 9 characters long");

            if (string.IsNullOrEmpty(updatedEmployee.Role))
                throw new ArgumentException("Employee's role can't be null");

            if (updatedEmployee.SalaryHour < 5.75)
                throw new ArgumentException("Employee's salary must be at least the minimum wage");

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
        public bool DeleteEmployee(Employee e)
        {
            if (e == null)
                return false;

            if (!EmployeeExists(e))
                throw new ArgumentException("Employee doesn't exist");

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

        #endregion

    }
}