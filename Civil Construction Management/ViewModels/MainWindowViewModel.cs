using Civil_Construction_Management.ViewModels.Interfaces;
using System.Windows.Input;

namespace Civil_Construction_Management.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {

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
                }
            }
        }
               
        public ICommand ShowEmployeesCommand { get; }

        public MainWindowViewModel(IManagerEmployee managerEmployee)
        {

            _currentViewModel = CurrentViewModel;
            _managerEmployee = managerEmployee;

            ShowEmployeesCommand = new ViewModelCommand(ExecuteShowEmployeesCommand);
        }


        private void ExecuteShowEmployeesCommand(object parameter)
        {

            CurrentViewModel = new ListingEmployeeViewModel(_managerEmployee);
        }
    }
}
