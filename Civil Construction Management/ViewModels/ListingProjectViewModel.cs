using Civil_Construction_Management.Models;
using Civil_Construction_Management.ViewModels.Enums;
using Civil_Construction_Management.ViewModels.Interfaces;
using Microsoft.Extensions.DependencyInjection;
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
        private Project _selectedObject;
        private Material _selectedMaterial;

        #endregion


        #region Public Properties

        public Material SelectedMaterial
        {
            get => _selectedMaterial;
            set
            {
                if(_selectedMaterial != value)
                {
                    _selectedMaterial = value;
                    OnPropertyChanged(nameof(SelectedMaterial));
                }
            }
        }

        public Project SelectedObject
        {
            get => _selectedObject;
            set
            {
                if (_selectedObject != value)
                {

                    _selectedObject = value;
                    OnPropertyChanged(nameof(SelectedObject));
                }
            }
        }

        public ObservableCollection<Project> Projects => _projects;

        public ICommand AddMaterialCommand { get; }
        public ICommand DeleteMaterialCommand { get; }

        #endregion


        #region Constructor

        public ListingProjectViewModel(IViewFactory viewFactory, IManagerProject managerProject)
        {

            _managerProject = managerProject;
            _viewFactory = viewFactory;
            _projects = new ObservableCollection<Project>();

            AddMaterialCommand = new ViewModelCommand(ExecuteAddMaterialWindowCommand);
            DeleteMaterialCommand = new ViewModelCommand(ExecuteDeleteMaterialWindowCommand);

            LoadProjects();
        }

        #endregion


        #region Methods

        private void LoadProjects()
        {

            var proj = _managerProject.LoadProjects();
            foreach (Project p in proj)
            {
                _projects.Add(p);
            }
        }

        public void ExecuteAddProjectWindowCommand(object parameter)
        {

            Window addProjectWindow = _viewFactory.CreateView(ViewType.AddProject);
            addProjectWindow.ShowDialog();

            _projects.Clear();
            LoadProjects();
        }

        public void ExecuteEditProjectWindowCommand(object parameter)
        {

            var viewModel = new ProjectViewModel(_selectedObject, _managerProject);

            Window editProjectWindow = _viewFactory.CreateView(ViewType.AddProject);
            editProjectWindow.DataContext = viewModel;
            
            viewModel.HideWindowAction = () => editProjectWindow.Hide();

            editProjectWindow.ShowDialog();

            _projects.Clear();
            LoadProjects();
        }

        public void ExecuteDeleteProjectWindowCommand(object parameter)
        {

            if (parameter is not Project proj)
                return;

            MessageBoxResult confirmation = MessageBox.Show($"Are you sure you want to delete the project with ID: {proj.ID}?",
                "Confirm elimination?",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (confirmation == MessageBoxResult.Yes)
            {

                bool success = _managerProject.DeleteProject(proj);
                if (success)
                {
                    _projects.Remove(proj);
                    MessageBox.Show("Project removed successfully.");
                }
                else
                    MessageBox.Show("Not possible.");
            }
            else
                return;
        }

        public void ExecuteAddMaterialWindowCommand(object parameter)
        {

            if (parameter is not Project p)
            {
                return;
                throw new ArgumentNullException("Object not selected");
            }

            var viewModel = App.ServiceProvider.GetRequiredService<MaterialViewModel>();
            viewModel.ProjectID = p.ID; // MaterialViewModel gets the ProjectID

            Window addMaterialWindow = _viewFactory.CreateView(ViewType.AddMaterial);
            addMaterialWindow.DataContext = viewModel;

            viewModel.HideWindowAction = () => addMaterialWindow.Hide();

            addMaterialWindow.ShowDialog();            

            _projects.Clear();
            LoadProjects();
        }

        public void ExecuteDeleteMaterialWindowCommand(object parameter)
        {

            if (parameter is not Material material)
                return;

            MessageBoxResult confirmation = MessageBox.Show($"Are you sure you want to delete {material.Name}?",
                "Confirm elimination?",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (confirmation == MessageBoxResult.Yes)
            {

                bool success = _managerProject.DeleteMaterial(material);
                if (success)                                    
                    MessageBox.Show($"{material.Name} removed successfully.");                
                else
                    MessageBox.Show("Not possible.");
            }
            else
                return;
        }

        #endregion

    }
}
