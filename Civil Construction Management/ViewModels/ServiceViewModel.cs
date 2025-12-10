using Civil_Construction_Management.Models;
using Civil_Construction_Management.ViewModels.Interfaces;
using System.Windows.Input;

namespace Civil_Construction_Management.ViewModels
{
    public class ServiceViewModel : BaseViewModel
    {

        #region Private Fields

        private IManagerProject _managerProject;
        private Service _service;

        #endregion


        #region Public Properties

        public int ProjectID
        {
            get => _service.ProjectID;
            set
            {
                if(_service.ProjectID != value)
                {
                    _service.ProjectID = value;
                    OnPropertyChanged(nameof(ProjectID));
                }
            }
        }

        public string CompanyName
        {
            get => _service.CompanyName;
            set
            {
                if(_service.CompanyName != value)
                {
                    _service.CompanyName = value;
                    OnPropertyChanged(nameof(CompanyName));
                }
            }
        }

        public double ServiceHours
        {
            get => _service.ServiceHours;
            set
            {
                if(_service.ServiceHours != value)
                {
                    _service.ServiceHours = value;
                    OnPropertyChanged(nameof(ServiceHours));
                }
            }
        }

        public string Status
        {
            get => _service.Status;
            set
            {
                if(_service.Status != value)
                {
                    _service.Status = value;
                    OnPropertyChanged(nameof(Status));
                }
            }
        }

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

        public DateTime EndDate
        {
            get => _service.EndDate;
            set
            {
                if(_service.EndDate != value)
                {
                    _service.EndDate = value;
                    OnPropertyChanged(nameof(EndDate));
                }
            }
        }

        public Action? HideWindowAction { get; set; }
        public ICommand SaveServiceCommand { get; }

        #endregion


        #region Constructor

        public ServiceViewModel(IManagerProject managerProject)
        {
            _service = new Service(string.Empty, 0, string.Empty, DateTime.Now, DateTime.Now);

            _managerProject = managerProject;

            SaveServiceCommand = new ViewModelCommand(ExecuteSaveCommand);
        }

        #endregion


        #region Methods

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
