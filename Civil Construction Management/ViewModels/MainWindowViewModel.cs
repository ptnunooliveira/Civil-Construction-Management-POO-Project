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
                }
            }
        }
               
        public ICommand ShowEmployeesCommand { get; }
        public ICommand CurrentAddCommand { get; set; }

        public MainWindowViewModel(IManagerEmployee managerEmployee, IViewFactory viewFactory)
        {

            _currentViewModel = CurrentViewModel;
            _managerEmployee = managerEmployee;
            _viewFactory = viewFactory;

            ShowEmployeesCommand = new ViewModelCommand(ExecuteShowEmployeesCommand);
            UpdateAddCommand();
        }


        private void ExecuteShowEmployeesCommand(object parameter)
        {

            CurrentViewModel = new ListingEmployeeViewModel(_managerEmployee, _viewFactory);
        }

        private void UpdateAddCommand()
        {
            if(CurrentViewModel is ListingEmployeeViewModel levm)
            {

                CurrentAddCommand = new ViewModelCommand(levm.ExecuteAddEmployeeWindowCommand);
                OnPropertyChanged(nameof(CurrentAddCommand));
            }
        }
    }
}
