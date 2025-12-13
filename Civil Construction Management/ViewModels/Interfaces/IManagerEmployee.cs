using Civil_Construction_Management.Models;

namespace Civil_Construction_Management.ViewModels.Interfaces
{
    /// <summary>
    /// Provides methods for managing employee data, including creating,
    /// updating, deleting, and retrieving employee records.
    /// </summary>
    public interface IManagerEmployee
    {
        /// <summary>
        /// Creates a new employee and stores it in the repository.
        /// </summary>
        /// <param name="e">The employee object to create.</param>
        /// <returns>True if creation was successful; otherwise, false.</returns>
        public bool CreateEmployee(Employee e);

        /// <summary>
        /// Checks whether a given employee already exists.
        /// </summary>
        /// <param name="e">The employee to validate.</param>
        /// <returns>True if the employee exists; otherwise, false.</returns>
        public bool EmployeeExists(Employee e);

        /// <summary>
        /// Deletes an existing employee from the repository.
        /// </summary>
        /// <param name="e">The employee to delete.</param>
        /// <returns>True if deletion was successful; otherwise, false.</returns>
        public bool DeleteEmployee(Employee e);

        /// <summary>
        /// Updates the information of an existing employee.
        /// </summary>
        /// <param name="updatedEmployee">The employee object containing updated data.</param>
        /// <returns>True if the update was successful; otherwise, false.</returns>
        public bool UpdateEmployee(Employee updatedEmployee);

        /// <summary>
        /// Retrieves all employees stored in the repository.
        /// </summary>
        /// <returns>A list of all employees.</returns>
        public List<Employee> GetAllEmployees();
    }
}