using Civil_Construction_Management.Models;
using Civil_Construction_Management.ViewModels.Enums;
using Civil_Construction_Management.ViewModels.Interfaces;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Civil_Construction_Management.ViewModels
{
    public class ListingProjectViewModel : BaseViewModel
    {

        #region Private Fields

        private readonly ObservableCollection<Project> _projects;
        private readonly IManagerProject _managerProject;
        private IViewFactory _viewFactory;
        private Project _selectedProject;

        #endregion

        #region Public Properties

        public Project SelectedProject
        {
            get => _selectedProject;
            set
            {
                if (_selectedProject != value)
                {

                    _selectedProject = value;
                    OnPropertyChanged(nameof(SelectedProject));
                }
            }
        }

        public ObservableCollection<Project> Projects => _projects;

        #endregion

        public ListingProjectViewModel(IViewFactory viewFactory, IManagerProject managerProject)
        {

            _managerProject = managerProject;
            _viewFactory = viewFactory;
            _projects = new ObservableCollection<Project>();

            LoadProjects();
        }


        public void ExecuteAddProjectWindowCommand(object parameter)
        {

            Window addEmployeeWindow = _viewFactory.CreateView(ViewType.AddProject);
            addEmployeeWindow.Show();
        }

        private void LoadProjects()
        {

            var proj = _managerProject.LoadProjects();
            foreach(Project p in proj)
            {
                _projects.Add(p);
            }
        }
    }
}
