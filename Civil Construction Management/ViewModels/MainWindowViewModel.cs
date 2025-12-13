using Civil_Construction_Management.ViewModels.Interfaces;
using System.Windows.Input;

namespace Civil_Construction_Management.ViewModels
{
    /// <summary>
    /// ViewModel for the Main Window. Handles navigation between different sections
    /// (Employees and Projects) and manages context-sensitive commands such as Add, Edit, and Delete.
    /// </summary>
    public class MainWindowViewModel : BaseViewModel
    {

        #region Private Fields

        /// <summary>
        /// Factory responsible for creating ViewModels and Views.
        /// </summary>
        private IViewFactory _viewFactory;

        /// <summary>
        /// The ViewModel currently displayed in the main content area.
        /// </summary>
        private BaseViewModel _currentViewModel;

        /// <summary>
        /// Service responsible for handling employee-related operations.
        /// </summary>
        private IManagerEmployee _managerEmployee;

        /// <summary>
        /// Service used to display messages to the user.
        /// </summary>
        private IMessageService _messageService;

        /// <summary>
        /// Service responsible for handling project-related operations.
        /// </summary>
        private IManagerProject _managerProject;

        #endregion


        #region Public Properties

        /// <summary>
        /// Gets or sets the currently active ViewModel displayed in the main window.
        /// Changing this property updates the available context commands.
        /// </summary>
        public BaseViewModel CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                if (_currentViewModel != value)
                {
                    _currentViewModel = value;
                    OnPropertyChanged(nameof(CurrentViewModel));

                    // Update Add/Edit/Delete commands based on the selected ViewModel
                    UpdateCommands();
                }
            }
        }

        /// <summary>
        /// Command that switches the current view to the Employees listing.
        /// </summary>
        public ICommand ShowEmployeesCommand { get; }

        /// <summary>
        /// Command that switches the current view to the Projects listing.
        /// </summary>
        public ICommand ShowProjectsCommand { get; }

        /// <summary>
        /// Context command used to add a new entity (Employee or Project).
        /// </summary>
        public ICommand CurrentAddCommand { get; set; }

        /// <summary>
        /// Context command used to edit the selected entity (Employee or Project).
        /// </summary>
        public ICommand CurrentEditCommand { get; set; }

        /// <summary>
        /// Context command used to delete the selected entity (Employee or Project).
        /// </summary>
        public ICommand CurrentDeleteCommand { get; set; }

        #endregion


        #region Constructors

        /// <summary>
        /// Initializes a new instance of the MainWindowViewModel and configures navigation commands.
        /// </summary>
        public MainWindowViewModel(
            IManagerEmployee managerEmployee,
            IViewFactory viewFactory,
            IMessageService messageService,
            IManagerProject managerProject)
        {
            _currentViewModel = CurrentViewModel;
            _managerEmployee = managerEmployee;
            _viewFactory = viewFactory;
            _messageService = messageService;
            _managerProject = managerProject;

            ShowEmployeesCommand = new ViewModelCommand(ExecuteShowEmployeesCommand);
            ShowProjectsCommand = new ViewModelCommand(ExecuteShowProjectsCommand);

            // Initialize context commands based on default CurrentViewModel
            UpdateCommands();
        }

        #endregion


        #region Methods

        /// <summary>
        /// Switches the current ViewModel to the Employee listing view.
        /// </summary>
        private void ExecuteShowEmployeesCommand(object parameter)
        {
            CurrentViewModel = new ListingEmployeeViewModel(
                _managerEmployee,
                _viewFactory,
                _messageService,
                _managerProject);
        }

        /// <summary>
        /// Switches the current ViewModel to the Project listing view.
        /// </summary>
        private void ExecuteShowProjectsCommand(object parameter)
        {
            CurrentViewModel = new ListingProjectViewModel(
                _viewFactory,
                _managerProject,
                _managerEmployee);
        }

        /// <summary>
        /// Updates the Add, Edit, and Delete commands based on the type
        /// of the currently selected ViewModel. Ensures that the same
        /// UI buttons perform context-appropriate actions.
        /// </summary>
        private void UpdateCommands()
        {
            // If the current view is the Employees listing
            if (CurrentViewModel is ListingEmployeeViewModel levm)
            {
                CurrentAddCommand = new ViewModelCommand(levm.ExecuteAddEmployeeWindowCommand);
                OnPropertyChanged(nameof(CurrentAddCommand));

                CurrentEditCommand = new ViewModelCommand(levm.ExecuteEditEmployeeWindowCommand);
                OnPropertyChanged(nameof(CurrentEditCommand));

                CurrentDeleteCommand = new ViewModelCommand(levm.ExecuteDeleteEmployeeWindowCommand);
                OnPropertyChanged(nameof(CurrentDeleteCommand));
            }

            // If the current view is the Projects listing
            else if (CurrentViewModel is ListingProjectViewModel lpvm)
            {
                CurrentAddCommand = new ViewModelCommand(lpvm.ExecuteAddProjectWindowCommand);
                OnPropertyChanged(nameof(CurrentAddCommand));

                CurrentEditCommand = new ViewModelCommand(lpvm.ExecuteEditProjectWindowCommand);
                OnPropertyChanged(nameof(CurrentEditCommand));

                CurrentDeleteCommand = new ViewModelCommand(lpvm.ExecuteDeleteProjectWindowCommand);
                OnPropertyChanged(nameof(CurrentDeleteCommand));
            }
        }

        #endregion
    }
}