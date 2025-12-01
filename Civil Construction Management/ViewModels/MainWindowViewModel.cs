using Civil_Construction_Management.ViewModels.Interfaces;
using System.Windows.Input;

namespace Civil_Construction_Management.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {

        private IViewFactory _viewFactory;
        private BaseViewModel _currentViewModel;        
        private IManagerEmployee _managerEmployee;

        public BaseViewModel CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                if(_currentViewModel != value)
                {
                    _currentViewModel = value;
                    OnPropertyChanged(nameof(CurrentViewModel));

                    UpdateAddCommand();
                    UpdateEditCommand();
                    UpdateDeleteCommand();
                }
            }
        }
               
        public ICommand ShowEmployeesCommand { get; }
        public ICommand CurrentAddCommand { get; set; }
        public ICommand CurrentEditCommand { get; set; }
        public ICommand CurrentDeleteCommand { get; set; }

        public MainWindowViewModel(IManagerEmployee managerEmployee, IViewFactory viewFactory)
        {

            _currentViewModel = CurrentViewModel;
            _managerEmployee = managerEmployee;
            _viewFactory = viewFactory;

            ShowEmployeesCommand = new ViewModelCommand(ExecuteShowEmployeesCommand);
            UpdateAddCommand();
            UpdateEditCommand();
            UpdateDeleteCommand();
        }


        // If user clicks on Employee's button, current ViewModel must change to EmployeeViewModel
        private void ExecuteShowEmployeesCommand(object parameter)
        {

            CurrentViewModel = new ListingEmployeeViewModel(_managerEmployee, _viewFactory);
        }
        
        // Update the Add button, which is the same button for every viewmodel
        private void UpdateAddCommand()
        {
            if(CurrentViewModel is ListingEmployeeViewModel levm)
            {

                CurrentAddCommand = new ViewModelCommand(levm.ExecuteAddEmployeeWindowCommand);
                OnPropertyChanged(nameof(CurrentAddCommand));
            }
        }

        private void UpdateEditCommand()
        {
            if(CurrentViewModel is ListingEmployeeViewModel levm)
            {

                CurrentEditCommand = new ViewModelCommand(levm.ExecuteEditEmployeeWindowCommand);
                OnPropertyChanged(nameof(CurrentEditCommand));
            }
        }

        private void UpdateDeleteCommand()
        {
            if(CurrentViewModel is ListingEmployeeViewModel levm)
            {

                CurrentDeleteCommand = new ViewModelCommand(levm.ExecuteDeleteEmployeeWindowCommand);
                OnPropertyChanged(nameof(CurrentDeleteCommand));
            }
        }
    }
}
