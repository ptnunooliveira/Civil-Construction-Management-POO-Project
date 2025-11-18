using Civil_Construction_Management.Models;
using Civil_Construction_Management.ViewModel.MaterialFolder;
using System.Collections.ObjectModel;

namespace Civil_Construction_Management.ViewModel.ProjectsFolder
{
    public class ProjectViewModel : BaseViewModel
    {

        private readonly Project _project;
        public int ID => _project.ID;
        public string ClientName => _project.ClientName;
        public string Address => _project.Address;
        public string Status => _project.Status.ToString();
        public Budget Budget => _project.Budget;

        public ObservableCollection<MaterialViewModel> Materials { get; }


        public ProjectViewModel(Project project)
        {
            _project = project;

            Materials = new ObservableCollection<MaterialViewModel>(_project.Materials.Select(m => new MaterialViewModel(m)));
        }

    }
}
