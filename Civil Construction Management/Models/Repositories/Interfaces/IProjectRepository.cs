namespace Civil_Construction_Management.Models.Repositories.Interfaces
{
    /// <summary>
    /// Interface that defines the contract for managing project data and associated resources.
    /// </summary>
    public interface IProjectRepository
    {
        /// <summary>
        /// Adds a new project to the repository.
        /// </summary>
        /// <param name="p">The Project object to add.</param>
        /// <returns>True if the project was added successfully; otherwise, False.</returns>
        public bool AddProject(Project p);

        /// <summary>
        /// Loads and returns all projects from the repository.
        /// </summary>
        /// <returns>A list of Project objects.</returns>
        public List<Project> LoadProjects();

        /// <summary>
        /// Retrieves a project based on its unique ID.
        /// </summary>
        /// <param name="id">The unique identifier of the project.</param>
        /// <returns>The corresponding Project object, or null if not found.</returns>
        public Project GetProjectByID(int id);

        /// <summary>
        /// Writes or updates project data to a chosen storage source (e.g., file or database).
        /// </summary>
        /// <param name="projects">The list of projects to store.</param>
        /// <returns>True if the data was successfully written; otherwise, False.</returns>
        public bool WriteProjects(List<Project> projects);

        /// <summary>
        /// Deletes a project from the repository.
        /// </summary>
        /// <param name="p">The Project object to delete.</param>
        /// <returns>True if the project was deleted successfully; otherwise, False.</returns>
        public bool DeleteProject(Project p);

        /// <summary>
        /// Adds a material to a specific project.
        /// </summary>
        /// <param name="projectID">The ID of the project to update.</param>
        /// <param name="material">The Material object to add.</param>
        /// <returns>True if the material was added successfully; otherwise, False.</returns>
        public bool AddMaterialToProject(int projectID, Material material);

        /// <summary>
        /// Removes a material from the repository or project (depending on implementation).
        /// </summary>
        /// <param name="material">The Material object to remove.</param>
        /// <returns>True if the material was removed successfully; otherwise, False.</returns>
        public bool DeleteMaterial(Material material);

        /// <summary>
        /// Adds a service to a specific project.
        /// </summary>
        /// <param name="projectID">The ID of the project to update.</param>
        /// <param name="service">The Service object to add.</param>
        /// <returns>True if the service was added successfully; otherwise, False.</returns>
        public bool AddServiceToProject(int projectID, Service service);

        /// <summary>
        /// Removes a service from the repository or project (depending on implementation).
        /// </summary>
        /// <param name="service">The Service object to remove.</param>
        /// <returns>True if the service was removed successfully; otherwise, False.</returns>
        public bool DeleteService(Service service);

        /// <summary>
        /// Adds an employee to a specific project.
        /// </summary>
        /// <param name="projectID">The ID of the project to update.</param>
        /// <param name="employee">The Employee object to add.</param>
        /// <returns>True if the employee was added successfully; otherwise, False.</returns>
        public bool AddEmployeeToProject(int projectID, Employee employee);

        /// <summary>
        /// Removes an employee from the repository or project (depending on implementation).
        /// </summary>
        /// <param name="employee">The Employee object to remove.</param>
        /// <returns>True if the employee was removed successfully; otherwise, False.</returns>
        public bool DeleteEmployee(Employee employee);
    }
}