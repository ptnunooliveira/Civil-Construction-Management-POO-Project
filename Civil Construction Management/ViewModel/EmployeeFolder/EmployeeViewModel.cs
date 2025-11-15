using Civil_Construction_Management.Models;

namespace Civil_Construction_Management.ViewModel.EmployeeFolder
{
    public class EmployeeViewModel : BaseViewModel
    {
        private readonly Employee _employee;

        public int ID => _employee.ID;
        public string Name => _employee.Name;
        public string NIF => _employee.NIF;
        public string PhoneNumber => _employee.PhoneNumber;
        public string Email => _employee.Email;
        public string Role => _employee.Role.ToString();
        public double SalaryHour => _employee.SalaryHour;
        public double WorkHours => _employee.WorkHours;
        public DateTime StartDate => _employee.StartDate;


        public EmployeeViewModel(Employee employee)
        {
            _employee = employee;
        }

    }
}
