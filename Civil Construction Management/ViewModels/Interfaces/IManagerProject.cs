using Civil_Construction_Management.Models;

namespace Civil_Construction_Management.ViewModels.Interfaces
{
    public interface IManagerProject
    {

        public bool AddProject(Project p);
        public List<Project> LoadProjects();
    }
}
