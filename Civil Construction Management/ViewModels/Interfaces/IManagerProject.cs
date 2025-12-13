using Civil_Construction_Management.Models;

namespace Civil_Construction_Management.ViewModels.Interfaces
{
    /// <summary>
    /// Provides high-level project management functionalities such as adding,
    /// updating, and deleting projects, as well as managing related materials,
    /// services, and employees.
    /// </summary>
    public interface IManagerProject
    {

        /// <summary>
        /// Adds a new project to the repository.
        /// </summary>
        /// <param name="p">The project to add.</param>
        /// <returns>True if the project was successfully added; otherwise, false.</returns>
        public bool AddProject(Project p);

        /// <summary>
        /// Loads and returns all stored projects.
        /// </summary>
        /// <returns>A list of all projects.</returns>
        public List<Project> LoadProjects();

        /// <summary>
        /// Deletes an existing project from the repository.
        /// </summary>
        /// <param name="p">The project to delete.</param>
        /// <returns>True if deletion was successful; otherwise, false.</returns>
        public bool DeleteProject(Project p);

        /// <summary>
        /// Updates the data of an existing project.
        /// </summary>
        /// <param name="editedProject">The project containing updated information.</param>
        /// <returns>True if the update was successful; otherwise, false.</returns>
        public bool UpdateProject(Project editedProject);

        /// <summary>
        /// Adds a material to a specific project.
        /// </summary>
        /// <param name="projectID">The ID of the project.</param>
        /// <param name="material">The material to add.</param>
        /// <returns>True if the material was successfully added; otherwise, false.</returns>
        public bool AddMaterialToProject(int projectID, Material material);

        /// <summary>
        /// Deletes a material from its associated project.
        /// </summary>
        /// <param name="material">The material to delete.</param>
        /// <returns>True if deletion was successful; otherwise, false.</returns>
        public bool DeleteMaterial(Material material);

        /// <summary>
        /// Adds a service to a specific project.
        /// </summary>
        /// <param name="projectID">The ID of the project.</param>
        /// <param name="service">The service to add.</param>
        /// <returns>True if the service was successfully added; otherwise, false.</returns>
        public bool AddServiceToProject(int projectID, Service service);

        /// <summary>
        /// Deletes a service from its associated project.
        /// </summary>
        /// <param name="service">The service to delete.</param>
        /// <returns>True if deletion was successful; otherwise, false.</returns>
        public bool DeleteService(Service service);

        /// <summary>
        /// Adds an employee to a specific project.
        /// </summary>
        /// <param name="projectID">The ID of the project.</param>
        /// <param name="employee">The employee to add.</param>
        /// <returns>True if the employee was successfully added; otherwise, false.</returns>
        public bool AddEmployeeToProject(int projectID, Employee employee);

        /// <summary>
        /// Removes an employee from its associated project.
        /// </summary>
        /// <param name="employee">The employee to remove.</param>
        /// <returns>True if deletion was successful; otherwise, false.</returns>
        public bool DeleteEmployee(Employee employee);
    }
}