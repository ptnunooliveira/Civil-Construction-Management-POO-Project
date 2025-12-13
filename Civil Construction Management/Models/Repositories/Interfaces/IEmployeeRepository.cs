namespace Civil_Construction_Management.Models.Repositories.Interfaces
{
    /// <summary>
    /// Interface that defines the contract for managing and accessing employee information.
    /// </summary>
    public interface IEmployeeRepository
    {
        /// <summary>
        /// Retrieves an employee based on their unique ID.
        /// </summary>
        /// <param name="id">The unique identifier of the employee.</param>
        /// <returns>The corresponding Employee object, or null if not found.</returns>
        public Employee GetEmployeeByID(int id);

        /// <summary>
        /// Adds a new employee to the repository.
        /// </summary>
        /// <param name="e">The Employee object to add.</param>
        /// <returns>True if the employee was added successfully; otherwise, False.</returns>
        public bool AddEmployee(Employee e);

        /// <summary>
        /// Removes an existing employee from the repository.
        /// </summary>
        /// <param name="e">The Employee object to remove.</param>
        /// <returns>True if the employee was removed successfully; otherwise, False.</returns>
        public bool RemoveEmployee(Employee e);

        /// <summary>
        /// Returns a list containing all employees in the repository.
        /// </summary>
        /// <returns>A list of Employee objects.</returns>
        public List<Employee> GetAllEmployees();

        /// <summary>
        /// Writes or updates the employee data to a chosen storage source (e.g., file or database).
        /// </summary>
        /// <param name="employees">The list of employees to store.</param>
        /// <returns>True if the data was successfully written; otherwise, False.</returns>
        public bool WriteEmployees(List<Employee> employees);
    }
}