using Civil_Construction_Management.Models;
using Civil_Construction_Management.ViewModels.Interfaces;
using System.Windows.Input;

namespace Civil_Construction_Management.ViewModels
{
    /// <summary>
    /// ViewModel responsible for creating and saving a new Service
    /// associated with a specific project. Handles property updates,
    /// validation triggers, and communication with the project manager service.
    /// </summary>
    public class ServiceViewModel : BaseViewModel
    {

        #region Private Fields

        /// <summary>
        /// Service responsible for managing project-related operations.
        /// </summary>
        private IManagerProject _managerProject;

        /// <summary>
        /// The internal Service model instance being created.
        /// </summary>
        private Service _service;

        #endregion


        #region Public Properties

        /// <summary>
        /// Gets or sets the ID of the project this service belongs to.
        /// </summary>
        public int ProjectID
        {
            get => _service.ProjectID;
            set
            {
                if (_service.ProjectID != value)
                {
                    _service.ProjectID = value;
                    OnPropertyChanged(nameof(ProjectID));
                }
            }
        }

        /// <summary>
        /// Gets or sets the name of the company providing the service.
        /// </summary>
        public string CompanyName
        {
            get => _service.CompanyName;
            set
            {
                if (_service.CompanyName != value)
                {
                    _service.CompanyName = value;
                    OnPropertyChanged(nameof(CompanyName));
                }
            }
        }

        /// <summary>
        /// Gets or sets the number of hours spent on the service.
        /// </summary>
        public double ServiceHours
        {
            get => _service.ServiceHours;
            set
            {
                if (_service.ServiceHours != value)
                {
                    _service.ServiceHours = value;
                    OnPropertyChanged(nameof(ServiceHours));
                }
            }
        }

        /// <summary>
        /// Gets or sets the current status of the service.
        /// </summary>
        public string Status
        {
            get => _service.Status;
            set
            {
                if (_service.Status != value)
                {
                    _service.Status = value;
                    OnPropertyChanged(nameof(Status));
                }
            }
        }

        /// <summary>
        /// Gets or sets the start date of the service.
        /// </summary>
        public DateTime StartDate
        {
            get => _service.StartDate;
            set
            {
                if (_service.StartDate != value)
                {
                    _service.StartDate = value;
                    OnPropertyChanged(nameof(StartDate));
                }
            }
        }

        /// <summary>
        /// Gets or sets the end date of the service.
        /// </summary>
        public DateTime EndDate
        {
            get => _service.EndDate;
            set
            {
                if (_service.EndDate != value)
                {
                    _service.EndDate = value;
                    OnPropertyChanged(nameof(EndDate));
                }
            }
        }

        /// <summary>
        /// Action delegate used to close the service creation window.
        /// </summary>
        public Action? HideWindowAction { get; set; }

        /// <summary>
        /// Command that triggers saving the service.
        /// </summary>
        public ICommand SaveServiceCommand { get; }

        #endregion


        #region Constructor

        /// <summary>
        /// Initializes a new instance of ServiceViewModel for creating a service.
        /// </summary>
        /// <param name="managerProject">Service responsible for project management.</param>
        public ServiceViewModel(IManagerProject managerProject)
        {
            // Start with a blank service model
            _service = new Service(string.Empty, 0, string.Empty, DateTime.Now, DateTime.Now);

            _managerProject = managerProject;

            SaveServiceCommand = new ViewModelCommand(ExecuteSaveCommand);
        }

        #endregion


        #region Methods

        /// <summary>
        /// Creates a new Service instance and sends it to the project manager service
        /// to be added to the specified project.
        /// </summary>
        /// <param name="parameter">Not used.</param>
        private void ExecuteSaveCommand(object parameter)
        {
            Service s = new Service(CompanyName, ServiceHours, Status, StartDate, EndDate);
            s.ProjectID = ProjectID;

            bool success = _managerProject.AddServiceToProject(ProjectID, s);
            if (!success)
                return;

            HideWindowAction?.Invoke();
        }

        #endregion
    }
}