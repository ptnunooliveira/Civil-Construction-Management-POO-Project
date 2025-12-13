using Civil_Construction_Management.Models.Repositories.Interfaces;
using DLL___Project_Support;
using System.IO;

namespace Civil_Construction_Management.Models.Repositories
{
    /// <summary>
    /// Repository responsible for handling CRUD operations for projects
    /// and managing associated materials, services, and employees.
    /// Data is persisted in a JSON file located in the Data directory.
    /// </summary>
    public class ProjectRepository : IProjectRepository
    {

        #region Setup

        private string _projectFile;
        private string _basePath = Path.Combine("." + Path.DirectorySeparatorChar, "Data");

        private readonly VerifyRepositories x = new VerifyRepositories();

        #endregion


        #region Constructor

        /// <summary>
        /// Initializes the repository, ensures the Data folder exists,
        /// and creates the projects.json file if it does not already exist.
        /// </summary>
        public ProjectRepository()
        {

            if (!Directory.Exists(_basePath))
                Directory.CreateDirectory(_basePath);

            _projectFile = Path.Combine(_basePath, "projects.json");

            if (!File.Exists(_projectFile))
                File.WriteAllText(_projectFile, "[]");
        }

        #endregion


        #region Methods

        #region Project

        /// <summary>
        /// Adds a new project to the repository and assigns a unique incremental ID.
        /// </summary>
        /// <param name="p">The Project object to add.</param>
        /// <returns>True if the project was added successfully; otherwise, False.</returns>
        public bool AddProject(Project p)
        {

            if (p == null)
                return false;

            var projs = LoadProjects();

            int newID = 1;

            foreach (var proj in projs)
            {
                if (proj.ID >= newID)
                    newID = proj.ID + 1;
            }

            p.ID = newID;

            projs.Add(p);

            return x.WriteJson<Project>(projs, _projectFile);
        }

        /// <summary>
        /// Retrieves a project based on its unique ID.
        /// </summary>
        /// <param name="id">The ID of the project.</param>
        /// <returns>The Project object if found; otherwise, null.</returns>
        public Project GetProjectByID(int id)
        {

            var proj = LoadProjects();

            return proj.FirstOrDefault(p => p.ID == id);
        }

        /// <summary>
        /// Loads and returns all projects stored in the repository.
        /// </summary>
        /// <returns>A list of Project objects.</returns>
        public List<Project> LoadProjects()
        {

            return x.ReadJson<Project>(_projectFile);
        }

        /// <summary>
        /// Writes or updates the list of projects in the JSON storage.
        /// </summary>
        /// <param name="projects">The list of projects to save.</param>
        /// <returns>True if writing was successful; otherwise, False.</returns>
        public bool WriteProjects(List<Project> projects)
        {

            if (projects == null)
                return false;

            return x.WriteJson<Project>(projects, _projectFile);
        }

        /// <summary>
        /// Deletes a project from the repository.
        /// </summary>
        /// <param name="p">The Project object to delete.</param>
        /// <returns>True if the project was deleted; otherwise, False.</returns>
        public bool DeleteProject(Project p)
        {
            if (p == null)
                return false;

            var projects = LoadProjects();
            if (projects == null)
                return false;

            var project = projects.FirstOrDefault<Project>(pr => pr.ID == p.ID);
            if (project == null)
                return false;

            projects.Remove(project);

            return x.WriteJson<Project>(projects, _projectFile);
        }

        #endregion


        #region Material

        /// <summary>
        /// Adds a material to a specific project.
        /// </summary>
        /// <param name="projectID">The ID of the project to update.</param>
        /// <param name="material">The Material object to add.</param>
        /// <returns>True if the material was added; otherwise, False.</returns>
        public bool AddMaterialToProject(int projectID, Material material)
        {

            if (projectID < 0 || material == null)
                return false;

            var projects = LoadProjects();
            if (projects == null)
                return false;

            var project = projects.FirstOrDefault<Project>(p => p.ID == projectID);
            if (project == null)
                return false;

            project.Materials.Add(material);

            return x.WriteJson<Project>(projects, _projectFile);
        }

        /// <summary>
        /// Removes a material from the project it belongs to.
        /// </summary>
        /// <param name="material">The Material object to remove.</param>
        /// <returns>True if the material was removed; otherwise, False.</returns>
        public bool DeleteMaterial(Material material)
        {

            if (material == null)
                return false;

            var projects = LoadProjects();
            if (projects == null)
                return false;

            var project = projects.FirstOrDefault<Project>(p => p.ID == material.ProjectID);
            if (project == null)
                return false;

            var materialToDelete = project.Materials.FirstOrDefault<Material>(m =>
                m.Name == material.Name &&
                m.Quantity == material.Quantity &&
                m.UnitPrice == material.UnitPrice);

            if (materialToDelete == null)
                return false;

            project.Materials.Remove(materialToDelete);

            return x.WriteJson<Project>(projects, _projectFile);
        }

        #endregion


        #region Service

        /// <summary>
        /// Adds a service to a specific project.
        /// </summary>
        /// <param name="projectID">The ID of the project.</param>
        /// <param name="service">The Service object to add.</param>
        /// <returns>True if the service was added; otherwise, False.</returns>
        public bool AddServiceToProject(int projectID, Service service)
        {

            if (projectID < 0 || service == null)
                return false;

            var projects = LoadProjects();
            if (projects == null)
                return false;

            var project = projects.FirstOrDefault<Project>(p => p.ID == projectID);
            if (project == null)
                return false;

            project.Services.Add(service);

            return x.WriteJson<Project>(projects, _projectFile);
        }

        /// <summary>
        /// Removes a service from the project it belongs to.
        /// </summary>
        /// <param name="service">The Service object to remove.</param>
        /// <returns>True if the service was removed; otherwise, False.</returns>
        public bool DeleteService(Service service)
        {

            if (service == null)
                return false;

            var projects = LoadProjects();
            if (projects == null)
                return false;

            var project = projects.FirstOrDefault<Project>(p => p.ID == service.ProjectID);
            if (project == null)
                return false;

            var serviceToDelete = project.Services.FirstOrDefault<Service>(s =>
                s.CompanyName == service.CompanyName &&
                s.Status == service.Status &&
                s.ServiceHours == service.ServiceHours &&
                s.StartDate == service.StartDate &&
                s.EndDate == service.EndDate);

            if (serviceToDelete == null)
                return false;

            project.Services.Remove(serviceToDelete);

            return x.WriteJson<Project>(projects, _projectFile);
        }

        #endregion


        #region Employee

        /// <summary>
        /// Adds an employee to a specific project.
        /// </summary>
        /// <param name="projectID">The ID of the project.</param>
        /// <param name="employee">The Employee object to add.</param>
        /// <returns>True if the employee was added; otherwise, False.</returns>
        public bool AddEmployeeToProject(int projectID, Employee employee)
        {

            if (projectID < 0 || employee == null)
                return false;

            var projects = LoadProjects();
            if (projects == null)
                return false;

            var project = projects.FirstOrDefault<Project>(p => p.ID == projectID);
            if (project == null)
                return false;

            project.Employees.Add(employee);

            return x.WriteJson<Project>(projects, _projectFile);
        }

        /// <summary>
        /// Removes an employee from the project they belong to.
        /// </summary>
        /// <param name="employee">The Employee object to remove.</param>
        /// <returns>True if the employee was removed; otherwise, False.</returns>
        public bool DeleteEmployee(Employee employee)
        {

            if (employee == null)
                return false;

            var projects = LoadProjects();
            if (projects == null)
                return false;

            var project = projects.FirstOrDefault<Project>(p => p.ID == employee.ProjectID);
            if (project == null)
                return false;

            var employeeToDelete = project.Employees.FirstOrDefault<Employee>(e =>
                e.ID == employee.ID);

            if (employeeToDelete == null)
                return false;

            project.Employees.Remove(employeeToDelete);

            return x.WriteJson<Project>(projects, _projectFile);
        }

        #endregion

        #endregion
    }
}