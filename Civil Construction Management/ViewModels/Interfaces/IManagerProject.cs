using Civil_Construction_Management.Models;

namespace Civil_Construction_Management.ViewModels.Interfaces
{
    public interface IManagerProject
    {

        public bool AddProject(Project p);
        public List<Project> LoadProjects();
        public bool DeleteProject(Project p);
        public bool UpdateProject(Project editedProject);
        public bool AddMaterialToProject(int projectID, Material material);
        public bool DeleteMaterial(Material material);
    }
}
