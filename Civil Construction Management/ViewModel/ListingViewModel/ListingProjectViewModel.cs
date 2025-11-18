using System.Collections.ObjectModel;

namespace Civil_Construction_Management.ViewModel.ProjectsFolder
{
    public class ListingProjectViewModel : BaseViewModel
    {

        private readonly ObservableCollection<ProjectViewModel> _projects;

        public ObservableCollection<ProjectViewModel> Projects => _projects;

        //public ICommand AddProjectCommand { get; }
        //public ICommand GoToEmployees_ProjectCommand { get; }


        public ListingProjectViewModel()
        {
            _projects = new ObservableCollection<ProjectViewModel>();
        }
    }
}
