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

        public bool AddProject(Project p)
        {

            if (p == null)
                return false;

            var proj = LoadProjects();

            int newID = proj.Count + 1;
            p.ID = newID;
            proj.Add(p);
            
            return x.WriteJson<Project>(proj, _projectFile);
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
    }
}
