using Civil_Construction_Management.Models;
using Civil_Construction_Management.ViewModels.Interfaces;
using System.Windows.Input;

namespace Civil_Construction_Management.ViewModels
{
    public class EmployeeViewModel : BaseViewModel
    {

        #region Private Fields

        private bool _editMode;
        private Employee _employee;
        private readonly IManagerEmployee _managerEmployee;
        
        #endregion


        #region Public Properties

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
                if(_employee.Role != value)
                {   
                    _employee.Role = value;
                    OnPropertyChanged(nameof(Role));                 
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

        public bool EditMode
        {
            get => _editMode;
            set
            {
                if(_editMode != value)
                {
                    _editMode = value;
                    OnPropertyChanged(nameof(EditMode));
                }
            }
        }

        public Action? HideWindowAction { get; set; }
        public ICommand SaveEmployeeCommand { get; }

        #endregion


        #region Constructors

        public EmployeeViewModel(IManagerEmployee managerEmployee)
        {

            _employee = new Employee("Name", "NIF", "Contact", "Email", "Role", 0, DateTime.Now);
            _editMode = false;
            
            _managerEmployee = managerEmployee;
            SaveEmployeeCommand = new ViewModelCommand(ExecuteSaveEmployeeCommand);            
        }
        public EmployeeViewModel(Employee employee, IManagerEmployee managerEmployee)
        {

            _employee = employee;
            _editMode = true;
                        
            _managerEmployee = managerEmployee;
            SaveEmployeeCommand = new ViewModelCommand(ExecuteSaveEmployeeCommand);
        }

        #endregion


        #region Methods

        public void ExecuteSaveEmployeeCommand(object parameter)
        {

            if (_editMode == false)
            {

                Employee e = new Employee(
                    Name,
                    NIF,
                    PhoneNumber,
                    Email,
                    Role,
                    SalaryHour,
                    StartDate.Date);

                bool success = CreateEmployee(e);
                if (!success)
                    throw new ArgumentException("It wasn't possible to create the employee.");
            }

            else if(_editMode == true)
            {
                var success = _managerEmployee.UpdateEmployee(_employee);
                if (!success)
                    return;
            }

            HideWindowAction?.Invoke();             
        }

        public bool CreateEmployee(Employee e)
        {
            
            if (e == null)
                throw new ArgumentException("Invalid argument.");

            return _managerEmployee.CreateEmployee(e);
        }
                
        #endregion
    }
}