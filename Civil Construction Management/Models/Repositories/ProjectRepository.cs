using Civil_Construction_Management.Models.Repositories.Interfaces;
using DLL___Project_Support;
using System.IO;

namespace Civil_Construction_Management.Models.Repositories
{
    public class ProjectRepository : IProjectRepository
    {

        private string _projectFile;
        private string _basePath = Path.Combine("." + Path.DirectorySeparatorChar, "Data");

        private readonly VerifyRepositories x = new VerifyRepositories();


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

        public bool AddProject(Project p)
        {

            if (p == null)
                return false;

            return x.AppendJson<Project>(p, _projectFile);
        }

        public List<Project> LoadProjects()
        {

            return x.ReadJson<Project>(_projectFile);
        }
    }
}
