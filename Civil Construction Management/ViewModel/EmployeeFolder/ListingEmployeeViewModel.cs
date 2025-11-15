using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Civil_Construction_Management.ViewModel.EmployeeFolder
{
    public class EmployeeListingViewModel : BaseViewModel
    {

        // The creation of EmployeeViewModel was necessary because the Employee Model don't implement INotifyChanged
        private readonly ObservableCollection<EmployeeViewModel> _employees;

        public ObservableCollection<EmployeeViewModel> Employees => _employees;

        // Commands for navegation purpose
        //public ICommand AddEmployeeCommand { get; }
        //public ICommand RemoveEmployeeCommand { get; }
        //public ICommand GoToVehicles_EmployeeCommand { get; }


        public EmployeeListingViewModel()
        {
            _employees = new ObservableCollection<EmployeeViewModel>();
        }

    }
}
