using Civil_Construction_Management.Models;
using Civil_Construction_Management.Models.Enums;
using Civil_Construction_Management.ViewModels.Interfaces;

namespace Civil_Construction_Management.ViewModels
{
    public class EmployeeViewModel : BaseViewModel
    {

        private Employee _employee;
        private readonly IManagerEmployee _managerEmployee;

        public string Name
        {
            get => _employee.Name;
            set
            {
                if(_employee.Name != value)
                {
                     _employee.Name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }
                
        public string NIF
        {
            get => _employee.NIF;
            set
            {
                if(_employee.NIF != value)
                {
                    _employee.NIF = value;
                    OnPropertyChanged(nameof(NIF));
                }
            }
        }

        public string PhoneNumber
        {
            get => _employee.PhoneNumber;
            set
            {
                if(_employee.PhoneNumber != value)
                {
                    _employee.PhoneNumber = value;
                    OnPropertyChanged(nameof(PhoneNumber));
                }
            }
        }

        public string Email
        {
            get => _employee.Email;
            set
            {
                if(_employee.Email != value)
                {
                    _employee.Email = value;
                    OnPropertyChanged(nameof(Email));
                }
            }
        }

        public string Role
        {
            get => _employee.Role.ToString();
            set
            {
                if(_employee.Role.ToString() != value)
                {
                    if (Enum.TryParse<Roles>(value, true, out Roles res))
                    {
                        _employee.Role = res;
                        OnPropertyChanged(nameof(Role));
                    }
                }
            }
        }

        public double SalaryHour
        {
            get => _employee.SalaryHour;
            set
            {
                if(_employee.SalaryHour != value)
                {
                    _employee.SalaryHour = value;
                    OnPropertyChanged(nameof(SalaryHour));
                }
            }
        }

        public double WorkHours
        {
            get => _employee.WorkHours;
            set
            {
                if(_employee.WorkHours != value)
                {
                    _employee.WorkHours = value;
                    OnPropertyChanged(nameof(WorkHours));
                }
            }
        }

        public DateTime StartDate
        {
            get => _employee.StartDate;
            set
            {
                if(_employee.StartDate != value)
                {
                    _employee.StartDate = value;
                    OnPropertyChanged(nameof(StartDate));
                }
            }
        }


        public EmployeeViewModel(Employee employee, IManagerEmployee managerEmployee)
        {

            _employee = employee;
            _managerEmployee = managerEmployee;
        }

        #region Methods

        public bool CreateEmployee(Employee e)
        {

            if (e == null)
                throw new ArgumentException("Invalid argument.");

            return _managerEmployee.CreateEmployee(e);
        }

        public bool DeleteEmployee(Employee e)
        {

            if (e == null)
                throw new ArgumentException("Invalid argument.");

            return _managerEmployee.DeleteEmployee(e);
        }

        #endregion
    }
}