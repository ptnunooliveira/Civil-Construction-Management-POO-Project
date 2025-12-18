using Civil_Construction_Management.Exceptions;
using Civil_Construction_Management.Models;
using Civil_Construction_Management.ViewModels.Interfaces;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Civil_Construction_Management.ViewModels
{
    /// <summary>
    /// ViewModel responsible for creating or editing a Project.
    /// Exposes project data to the UI, handles Save operations,
    /// and notifies the view when properties change.
    /// </summary>
    public class ProjectViewModel : BaseViewModel
    {

        #region Private Fields

        /// <summary>
        /// Indicates if the ViewModel is editing an existing project (true)
        /// or creating a new one (false).
        /// </summary>
        private bool _editMode;

        /// <summary>
        /// The project instance being created or modified.
        /// </summary>
        private Project _project;

        /// <summary>
        /// The project manager service responsible for project CRUD operations.
        /// </summary>
        private readonly IManagerProject _managerProject;

        #endregion


        #region Public Properties

        /// <summary>
        /// Gets or sets the project ID. Updates the UI when modified.
        /// </summary>
        public int ID
        {
            get => _project.ID;
            set
            {
                if (_project.ID != value)
                {
                    _project.ID = value;
                    OnPropertyChanged(nameof(ID));
                }
            }
        }

        /// <summary>
        /// Gets or sets the client's name associated with this project.
        /// </summary>
        public string ClientName
        {
            get => _project.ClientName;
            set
            {
                if (_project.ClientName != value)
                {
                    _project.ClientName = value;
                    OnPropertyChanged(nameof(ClientName));
                }
            }
        }

        /// <summary>
        /// Gets or sets the address where the project is located.
        /// </summary>
        public string Address
        {
            get => _project.Address;
            set
            {
                if (_project.Address != value)
                {
                    _project.Address = value;
                    OnPropertyChanged(nameof(Address));
                }
            }
        }

        /// <summary>
        /// Gets or sets the current status of the project (e.g. In Progress, Completed).
        /// </summary>
        public string Status
        {
            get => _project.Status;
            set
            {
                if (_project.Status != value)
                {
                    _project.Status = value;
                    OnPropertyChanged(nameof(Status));
                }
            }
        }

        /// <summary>
        /// List of materials associated with this project (not currently filled in this ViewModel).
        /// </summary>
        public ObservableCollection<MaterialViewModel> Materials { get; }

        /// <summary>
        /// Action that allows the ViewModel to close the window hosting this ViewModel.
        /// </summary>
        public Action? HideWindowAction { get; set; }

        /// <summary>
        /// Command that triggers saving (create or update) the project.
        /// </summary>
        public ICommand SaveProjectCommand { get; }

        #endregion


        #region Constructor

        /// <summary>
        /// Creates a new instance of ProjectViewModel in EDIT mode.
        /// </summary>
        /// <param name="p">The project to edit.</param>
        /// <param name="managerProject">Service that manages project data.</param>
        public ProjectViewModel(Project p, IManagerProject managerProject)
        {
            _editMode = true;
            _project = p;

            _managerProject = managerProject;

            SaveProjectCommand = new ViewModelCommand(ExecuteSaveProjectCommand);
        }

        /// <summary>
        /// Creates a new instance of ProjectViewModel in CREATE mode.
        /// Initializes a blank project template.
        /// </summary>
        public ProjectViewModel(IManagerProject managerProject)
        {
            _editMode = false;
            _project = new Project("Client Name", "Address", "Status");

            _managerProject = managerProject;

            SaveProjectCommand = new ViewModelCommand(ExecuteSaveProjectCommand);
        }

        #endregion


        #region Methods

        /// <summary>
        /// Saves the project. Behavior depends on whether the ViewModel is
        /// creating a new project or editing an existing one.
        /// </summary>
        public void ExecuteSaveProjectCommand(object parameter)
        {

            if (_editMode == false)
            {
                // Creating a new project
                Project p = new Project(
                    ClientName,
                    Address,
                    Status
                );

                try
                {

                    bool success = _managerProject.AddProject(p);

                    if (success)
                        HideWindowAction?.Invoke();
                }

                catch (ArgumentException e)
                {

                    MessageBox.Show(e.Message, "WARNING", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                catch (DataAccessException e)
                {

                    MessageBox.Show(e.Message, "WARNING", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            else if (_editMode == true)
            {

                try
                {
                    // Editing existing project
                    bool success = _managerProject.UpdateProject(_project);
                    if (!success)
                        return;

                    HideWindowAction?.Invoke();
                }

                catch (ArgumentException e)
                {

                    MessageBox.Show(e.Message, "WARNING", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                catch (DataAccessException e)
                {

                    MessageBox.Show(e.Message, "WARNING", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }                            
        }

        #endregion
    }
}
