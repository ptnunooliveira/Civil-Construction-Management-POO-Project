using Civil_Construction_Management.Models;
using Civil_Construction_Management.Models.Repositories.Interfaces;
using Civil_Construction_Management.ViewModels.Interfaces;

namespace Civil_Construction_Management.ViewModels.Services
{
    /// <summary>
    /// Provides higher-level operations for creating, updating, deleting,
    /// and managing projects and their related entities such as materials,
    /// services, and employees.
    /// </summary>
    public class ManagerProject : IManagerProject
    {
        #region Setup

        private readonly IProjectRepository _projectRepository;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of <see cref="ManagerProject"/>.
        /// </summary>
        /// <param name="projectRepository">The project repository used for data storage and retrieval.</param>
        public ManagerProject(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        #endregion

        #region Methods

        #region Project

        /// <summary>
        /// Adds a new project to the repository.
        /// </summary>
        /// <param name="p">The project to add.</param>
        /// <returns>True if the project was added; otherwise false.</returns>
        public bool AddProject(Project p)
        {
            if (p == null)
                throw new ArgumentException("Project can't be null.");

            if (p.ClientName.Length > 30)
                throw new ArgumentException("Client Name is too long. Must be 30 characters or less");

            if (p.Address.Length > 50)
                throw new ArgumentException("Project's address is too long. Must be 50 characters or less");

            if (p.Status.Length > 20)
                throw new ArgumentException("Project's status is too long. Must be 20 characters or less");

            return _projectRepository.AddProject(p);
        }

        /// <summary>
        /// Updates an existing project with new information.
        /// </summary>
        /// <param name="editedProject">The updated project data.</param>
        /// <returns>True if the update succeeded; otherwise false.</returns>
        public bool UpdateProject(Project editedProject)
        {
            if (editedProject == null)
                return false;

            if (editedProject.ClientName.Length > 30)
                throw new ArgumentException("Client Name is too long. Must be 30 characters or less");

            if (editedProject.Address.Length > 50)
                throw new ArgumentException("Project's address is too long. Must be 50 characters or less");

            if (editedProject.Status.Length > 20)
                throw new ArgumentException("Project's status is too long. Must be 20 characters or less");

            var projects = _projectRepository.LoadProjects();
            if (projects == null)
                return false;

            var oldProj = projects.FirstOrDefault(p => p.ID == editedProject.ID);
            if (oldProj == null)
                return false;

            oldProj.ClientName = editedProject.ClientName;
            oldProj.Address = editedProject.Address;
            oldProj.Status = editedProject.Status;

            return _projectRepository.WriteProjects(projects);
        }

        /// <summary>
        /// Loads all projects from the repository.
        /// </summary>
        /// <returns>A list of projects.</returns>
        public List<Project> LoadProjects()
        {

            return _projectRepository.LoadProjects();
        }

        /// <summary>
        /// Deletes the specified project.
        /// </summary>
        /// <param name="p">The project to delete.</param>
        /// <returns>True if the project was deleted; otherwise false.</returns>
        public bool DeleteProject(Project p)
        {
            if (p == null)
                return false;

            return _projectRepository.DeleteProject(p);
        }

        #endregion

        #region Material

        /// <summary>
        /// Adds a material to a specific project.
        /// </summary>
        /// <param name="projectID">The project ID.</param>
        /// <param name="material">The material to add.</param>
        /// <returns>True if the material was added; otherwise false.</returns>
        public bool AddMaterialToProject(int projectID, Material material)
        {

            if (projectID < 0 || material == null)
                return false;

            if (material.Name.Length > 50)
                throw new ArgumentException("Material name is too long. Must be 50 characters or less");

            if (material.Quantity < 1)
                throw new ArgumentException("Material's quantity must be at least one unit");

            if (material.UnitPrice <= 0)
                throw new ArgumentException("Material's unit price must be positive.");

            return _projectRepository.AddMaterialToProject(projectID, material);
        }

        /// <summary>
        /// Removes a material from a project.
        /// </summary>
        /// <param name="material">The material to remove.</param>
        /// <returns>True if the material was deleted; otherwise false.</returns>
        public bool DeleteMaterial(Material material)
        {

            if (material == null)
                return false;

            return _projectRepository.DeleteMaterial(material);
        }

        #endregion

        #region Service

        /// <summary>
        /// Adds a service to a project.
        /// </summary>
        /// <param name="projectID">The project ID.</param>
        /// <param name="service">The service to add.</param>
        /// <returns>True if the service was added; otherwise false.</returns>
        public bool AddServiceToProject(int projectID, Service service)
        {

            if (projectID < 0 || service == null)
                return false;

            if (service.CompanyName.Length > 30)
                throw new ArgumentException("Service's company name is too long. Must be 30 characters or less");

            if (service.ServiceHours < 0)
                throw new ArgumentException("Service hours must be positive.");

            if (service.Status.Length > 20)
                throw new ArgumentException("Service's status is too long. Must be 20 characters or less");

            if (service.EndDate < service.StartDate)
                throw new ArgumentException("End date must end after the start date");

            return _projectRepository.AddServiceToProject(projectID, service);
        }

        /// <summary>
        /// Removes a service from a project.
        /// </summary>
        /// <param name="service">The service to remove.</param>
        /// <returns>True if the service was removed; otherwise false.</returns>
        public bool DeleteService(Service service)
        {

            if (service == null)
                return false;

            return _projectRepository.DeleteService(service);
        }

        #endregion

        #region Employee

        /// <summary>
        /// Adds an employee to a project.
        /// </summary>
        /// <param name="projectID">The project ID.</param>
        /// <param name="employee">The employee to add.</param>
        /// <returns>True if the employee was added; otherwise false.</returns>
        public bool AddEmployeeToProject(int projectID, Employee employee)
        {

            if (projectID < 0 || employee == null)
                return false;

            return _projectRepository.AddEmployeeToProject(projectID, employee);
        }

        /// <summary>
        /// Removes an employee from a project.
        /// </summary>
        /// <param name="employee">The employee to remove.</param>
        /// <returns>True if the employee was removed; otherwise false.</returns>
        public bool DeleteEmployee(Employee employee)
        {
            if (employee == null)
                return false;

            return _projectRepository.DeleteEmployee(employee);
        }

        #endregion

        #endregion
    }
}