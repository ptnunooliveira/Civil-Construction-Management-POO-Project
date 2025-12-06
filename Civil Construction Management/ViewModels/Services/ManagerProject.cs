using Civil_Construction_Management.Models;
using Civil_Construction_Management.Models.Repositories.Interfaces;
using Civil_Construction_Management.ViewModels.Interfaces;

namespace Civil_Construction_Management.ViewModels.Services
{
    public class ManagerProject : IManagerProject
    {

        private IProjectRepository _projectRepository;

        public ManagerProject(IProjectRepository projectRepository)
        {

            _projectRepository = projectRepository;
        }

        public bool AddProject(Project p)
        {

            if (p == null)
                return false;

            return _projectRepository.AddProject(p);
        }

        public List<Project> LoadProjects()
        {

            return _projectRepository.LoadProjects();
        }
    }
}
