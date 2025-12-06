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

        private Project _project;
        private readonly IManagerProject _managerProject;

        #endregion

        #region Public Properties

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


        public ProjectViewModel(IManagerProject managerProject)
        {

            _project = new Project("Client Name", "Address", "Status");

            _managerProject = managerProject;

            SaveProjectCommand = new ViewModelCommand(ExecuteAddProjectCommand);
        }

        public void ExecuteAddProjectCommand(object parameter)
        {

            Project p = new Project(
                ClientName,
                Address,
                Status
                );

            bool success = _managerProject.AddProject(p);

            if (!success)
                MessageBox.Show("It wasn't possible to add the project.");           
        }
    }
}
