using Civil_Construction_Management.Models;
using Civil_Construction_Management.ViewModels.Interfaces;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Civil_Construction_Management.ViewModels
{
    public class ProjectViewModel : BaseViewModel
    {

        #region Private Fields

        private bool _editMode;
        private Project _project;
        private readonly IManagerProject _managerProject;

        #endregion


        #region Public Properties

        public int ID
        {
            get => _project.ID;
            set
            {
                if(_project.ID != value)
                {
                    _project.ID = value;
                    OnPropertyChanged(nameof(ID));
                }
            }
        }

        public string ClientName
        {
            get => _project.ClientName;
            set
            {
                if(_project.ClientName != value)
                {
                    _project.ClientName = value;
                    OnPropertyChanged(nameof(ClientName));
                }
            }
        }        

        public string Address
        {
            get => _project.Address;
            set
            {
                if(_project.Address != value)
                {
                    _project.Address = value;
                    OnPropertyChanged(nameof(Address));
                }
            }
        }

        public string Status
        {
            get => _project.Status;
            set
            {
                if(_project.Status != value)
                {
                    _project.Status = value;
                    OnPropertyChanged(nameof(Status)); 
                }
            }
        }

        public ObservableCollection<MaterialViewModel> Materials { get; }

        public Action? HideWindowAction { get; set; }
        public ICommand SaveProjectCommand { get; }

        #endregion


        #region Constructor

        public ProjectViewModel(Project p, IManagerProject managerProject)
        {
            _editMode = true;
            _project = p;

            _managerProject = managerProject;

            SaveProjectCommand = new ViewModelCommand(ExecuteSaveProjectCommand);
        }

        public ProjectViewModel(IManagerProject managerProject)
        {
            _editMode = false;
            _project = new Project("Client Name", "Address", "Status");

            _managerProject = managerProject;

            SaveProjectCommand = new ViewModelCommand(ExecuteSaveProjectCommand);
        }

        #endregion


        #region Methods

        public void ExecuteSaveProjectCommand(object parameter)
        {

            if (_editMode == false)
            {

                Project p = new Project(
                    ClientName,
                    Address,
                    Status
                    );

                bool success = _managerProject.AddProject(p);

                if (!success)
                    MessageBox.Show("It wasn't possible to add the project.");

                HideWindowAction?.Invoke();
            }

            else if(_editMode == true)
            {

                bool success = _managerProject.UpdateProject(_project);
                if (!success)
                    return;
            }

            HideWindowAction?.Invoke();
        }

        #endregion
    }
}
