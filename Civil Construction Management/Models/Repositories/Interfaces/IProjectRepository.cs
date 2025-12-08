namespace Civil_Construction_Management.Models.Repositories.Interfaces
{
    public interface IProjectRepository
    {

        public bool AddProject(Project p);
        public List<Project> LoadProjects();
        public Project GetProjectByID(int id);
        public bool WriteProjects(List<Project> projects);
        public bool DeleteProject(Project p);
        public bool AddMaterialToProject(int projectID, Material material);
        public bool DeleteMaterial(Material material);
    }
}
