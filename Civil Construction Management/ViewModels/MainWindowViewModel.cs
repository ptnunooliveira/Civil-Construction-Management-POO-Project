using Civil_Construction_Management.ViewModels.Interfaces;
using System.Windows.Input;

namespace Civil_Construction_Management.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {

        #region Private Fields

        private IViewFactory _viewFactory;
        private BaseViewModel _currentViewModel;        
        private IManagerEmployee _managerEmployee;
        private IMessageService _messageService;
        private IManagerProject _managerProject;

        #endregion


        #region Public Properties

        public BaseViewModel CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                if(_currentViewModel != value)
                {
                    _currentViewModel = value;
                    OnPropertyChanged(nameof(CurrentViewModel));

                    UpdateCommands();
                }
            }
        }
               
        public ICommand ShowEmployeesCommand { get; }
        public ICommand ShowProjectsCommand { get; }
        public ICommand CurrentAddCommand { get; set; }
        public ICommand CurrentEditCommand { get; set; }
        public ICommand CurrentDeleteCommand { get; set; }

        #endregion


        #region Constructors

        public MainWindowViewModel(IManagerEmployee managerEmployee, IViewFactory viewFactory, IMessageService messageService, IManagerProject managerProject)
        {

            _currentViewModel = CurrentViewModel;
            _managerEmployee = managerEmployee;
            _viewFactory = viewFactory;
            _messageService = messageService;
            _managerProject = managerProject;

            ShowEmployeesCommand = new ViewModelCommand(ExecuteShowEmployeesCommand);
            ShowProjectsCommand = new ViewModelCommand(ExecuteShowProjectsCommand);
            UpdateCommands();
        }

        #endregion


        #region Methods

        // If user clicks on Employee's button, current ViewModel must change to EmployeeViewModel
        private void ExecuteShowEmployeesCommand(object parameter)
        {

            CurrentViewModel = new ListingEmployeeViewModel(_managerEmployee, _viewFactory, _messageService, _managerProject);
        }

        private void ExecuteShowProjectsCommand(object parameter)
        {

            CurrentViewModel = new ListingProjectViewModel(_viewFactory, _managerProject, _managerEmployee);
        }

        // Button update, which is the same button for every viewmodel
        private void UpdateCommands()
        {
            if (CurrentViewModel is ListingEmployeeViewModel levm)
            {

                CurrentAddCommand = new ViewModelCommand(levm.ExecuteAddEmployeeWindowCommand);
                OnPropertyChanged(nameof(CurrentAddCommand));

                CurrentEditCommand = new ViewModelCommand(levm.ExecuteEditEmployeeWindowCommand);
                OnPropertyChanged(nameof(CurrentEditCommand));

                CurrentDeleteCommand = new ViewModelCommand(levm.ExecuteDeleteEmployeeWindowCommand);
                OnPropertyChanged(nameof(CurrentDeleteCommand));
            }

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
