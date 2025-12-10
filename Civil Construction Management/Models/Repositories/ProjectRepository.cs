using Civil_Construction_Management.Models.Repositories.Interfaces;
using DLL___Project_Support;
using System.IO;

namespace Civil_Construction_Management.Models.Repositories
{
    public class ProjectRepository : IProjectRepository
    {

        #region Setup

        private string _projectFile;
        private string _basePath = Path.Combine("." + Path.DirectorySeparatorChar, "Data");

        private readonly VerifyRepositories x = new VerifyRepositories();

        #endregion
        

        #region Constructor
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

        public bool AddProject(Project p)
        {

            if (p == null)
                return false;

            var projs = LoadProjects();

            int newID = 1;

            foreach(var proj in projs)
            {                
                if (proj.ID >= newID)
                    newID = proj.ID + 1;
            }

            p.ID = newID;

            projs.Add(p);
            
            return x.WriteJson<Project>(projs, _projectFile);
        }

        public Project GetProjectByID(int id)
        {

            var proj = LoadProjects();

            return proj.FirstOrDefault(p => p.ID == id);
        }

        public List<Project> LoadProjects()
        {

            return x.ReadJson<Project>(_projectFile);
        }

        public bool WriteProjects(List<Project> projects)
        {

            if (projects == null)
                return false;

            return x.WriteJson<Project>(projects, _projectFile);
        }

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

            var materialToDelete = project.Materials.FirstOrDefault<Material>(m => m.Name == material.Name && m.Quantity == material.Quantity && m.UnitPrice == material.UnitPrice);
            if (materialToDelete == null)
                return false;

            project.Materials.Remove(materialToDelete);

            return x.WriteJson<Project>(projects, _projectFile);
        }

        #endregion


        #region Service

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

            var serviceToDelete = project.Services.FirstOrDefault<Service>(s => s.CompanyName == service.CompanyName &&
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

            var employeeToDelete = project.Employees.FirstOrDefault<Employee>(e => e.ID == employee.ID);
            if (employeeToDelete == null)
                return false;

            project.Employees.Remove(employeeToDelete);

            return x.WriteJson<Project>(projects, _projectFile);
        }

        #endregion

        #endregion
    }
}
