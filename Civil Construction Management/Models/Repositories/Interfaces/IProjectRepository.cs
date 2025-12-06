namespace Civil_Construction_Management.Models.Repositories.Interfaces
{
    public interface IProjectRepository
    {

        public bool AddProject(Project p);

        public List<Project> LoadProjects();
    }
}
