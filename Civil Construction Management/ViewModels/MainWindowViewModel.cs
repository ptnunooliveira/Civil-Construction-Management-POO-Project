using System.Windows.Input;

namespace Civil_Construction_Management.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {

        private BaseViewModel _currentViewModel;

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

        public MainWindowViewModel()
        {
                       
            ShowEmployeesCommand = new ViewModelCommand(ExecuteShowEmployeesCommand);
        }


        private void ExecuteShowEmployeesCommand(object parameter)
        {

                      
        }
    }
}
