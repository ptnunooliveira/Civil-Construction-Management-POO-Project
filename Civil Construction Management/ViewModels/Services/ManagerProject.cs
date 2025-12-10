using Civil_Construction_Management.Models;
using Civil_Construction_Management.Models.Repositories.Interfaces;
using Civil_Construction_Management.ViewModels.Interfaces;

namespace Civil_Construction_Management.ViewModels.Services
{
    public class ManagerProject : IManagerProject
    {

        #region Setup

        private IProjectRepository _projectRepository;

        #endregion


        #region Constructor

        public ManagerProject(IProjectRepository projectRepository)
        {

            _projectRepository = projectRepository;
        }

        #endregion


        #region Methods

        #region Project

        public bool AddProject(Project p)
        {

            if (p == null)
                return false;

            return _projectRepository.AddProject(p);
        }

        public bool UpdateProject(Project editedProject)
        {
            
            if (editedProject == null)
                return false;

            var projects = _projectRepository.LoadProjects();
            if (projects == null)
                return false;

            var oldProj = projects.FirstOrDefault<Project>(p => p.ID == editedProject.ID);
            if (oldProj == null)
                return false;

            oldProj.ClientName = editedProject.ClientName;
            oldProj.Address = editedProject.Address;
            oldProj.Status = editedProject.Status;

            return _projectRepository.WriteProjects(projects);
        }

        public List<Project> LoadProjects()
        {

            return _projectRepository.LoadProjects();
        }

        public bool DeleteProject(Project p)
        {

            if (p == null)
                return false;

            return _projectRepository.DeleteProject(p);
        }

        #endregion


        #region Material

        public bool AddMaterialToProject(int projectID, Material material)
        {

            if (projectID < 0 || material == null)
                return false;

            return _projectRepository.AddMaterialToProject(projectID, material);
        }

        public bool DeleteMaterial(Material material)
        {

            if (material == null)
                return false;

            return _projectRepository.DeleteMaterial(material);
        }

        #endregion


        #region Service

        public bool AddServiceToProject(int projectID, Service service)
        {

            if (projectID < 0 || service == null)
                return false;

            return _projectRepository.AddServiceToProject(projectID, service);
        }

        public bool DeleteService(Service service)
        {
            if (service == null)
                return false;

            return _projectRepository.DeleteService(service);
        }

        #endregion


        #region Employee

        public bool AddEmployeeToProject(int projectID, Employee employee)
        {

            if (projectID < 0 || employee == null)
                return false;

            return _projectRepository.AddEmployeeToProject(projectID, employee);
        }

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
