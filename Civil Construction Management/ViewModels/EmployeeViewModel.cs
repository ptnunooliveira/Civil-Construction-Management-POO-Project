using Civil_Construction_Management.Exceptions;
using Civil_Construction_Management.Models;
using Civil_Construction_Management.ViewModels.Interfaces;
using System.Windows;
using System.Windows.Input;

namespace Civil_Construction_Management.ViewModels
{
    /// <summary>
    /// ViewModel responsible for creating or editing an Employee instance.
    /// Provides data binding properties and commands for UI interaction.
    /// </summary>
    public class EmployeeViewModel : BaseViewModel
    {

        #region Private Fields

        /// <summary>
        /// Indicates whether the ViewModel is currently editing an existing employee.
        /// If false, the ViewModel is creating a new employee.
        /// </summary>
        private bool _editMode;

        /// <summary>
        /// The employee instance being created or modified.
        /// </summary>
        private Employee _employee;

        /// <summary>
        /// Service responsible for performing CRUD operations on Employee objects.
        /// </summary>
        private readonly IManagerEmployee _managerEmployee;

        #endregion


        #region Public Properties

        /// <summary>
        /// Gets or sets the employee's ID value.
        /// </summary>
        public int ID
        {
            get => _employee.ID;
            set
            {
                if (_employee.ID != value)
                {
                    _employee.ID = value;
                    OnPropertyChanged(nameof(ID));
                }
            }
        }

        /// <summary>
        /// Gets or sets the employee's full name.
        /// </summary>
        public string Name
        {
            get => _employee.Name;
            set
            {
                if (_employee.Name != value)
                {
                    _employee.Name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        /// <summary>
        /// Gets or sets the employee's tax identification number (NIF).
        /// </summary>
        public string NIF
        {
            get => _employee.NIF;
            set
            {
                if (_employee.NIF != value)
                {
                    _employee.NIF = value;
                    OnPropertyChanged(nameof(NIF));
                }
            }
        }

        /// <summary>
        /// Gets or sets the employee's phone number.
        /// </summary>
        public string PhoneNumber
        {
            get => _employee.PhoneNumber;
            set
            {
                if (_employee.PhoneNumber != value)
                {
                    _employee.PhoneNumber = value;
                    OnPropertyChanged(nameof(PhoneNumber));
                }
            }
        }

        /// <summary>
        /// Gets or sets the employee's email address.
        /// </summary>
        public string Email
        {
            get => _employee.Email;
            set
            {
                if (_employee.Email != value)
                {
                    _employee.Email = value;
                    OnPropertyChanged(nameof(Email));
                }
            }
        }

        /// <summary>
        /// Gets or sets the employee's professional role or job title.
        /// </summary>
        public string Role
        {
            get => _employee.Role.ToString();
            set
            {
                if (_employee.Role != value)
                {
                    _employee.Role = value;
                    OnPropertyChanged(nameof(Role));
                }
            }
        }

        /// <summary>
        /// Gets or sets the hourly salary rate for the employee.
        /// </summary>
        public double SalaryHour
        {
            get => _employee.SalaryHour;
            set
            {
                if (_employee.SalaryHour != value)
                {
                    _employee.SalaryHour = value;
                    OnPropertyChanged(nameof(SalaryHour));
                }
            }
        }

        /// <summary>
        /// Gets or sets the date when the employee started working on the project.
        /// </summary>
        public DateTime StartDate
        {
            get => _employee.StartDate;
            set
            {
                if (_employee.StartDate != value)
                {
                    _employee.StartDate = value;
                    OnPropertyChanged(nameof(StartDate));
                }
            }
        }

        /// <summary>
        /// Action delegate used by the View to close the window associated with this ViewModel.
        /// </summary>
        public Action? HideWindowAction { get; set; }

        /// <summary>
        /// Command executed when the user chooses to save the employee's information.
        /// </summary>
        public ICommand SaveEmployeeCommand { get; }

        #endregion


        #region Constructors

        /// <summary>
        /// Creates a new instance of the EmployeeViewModel configured for creating a new employee.
        /// </summary>
        /// <param name="managerEmployee">The employee manager service.</param>
        public EmployeeViewModel(IManagerEmployee managerEmployee)
        {
            // Initialize with placeholder values
            _employee = new Employee("Name", "NIF", "Contact", "Email", "Role", 0, DateTime.Now);

            _editMode = false;
            _managerEmployee = managerEmployee;

            SaveEmployeeCommand = new ViewModelCommand(ExecuteSaveEmployeeCommand);
        }

        /// <summary>
        /// Creates a new instance of the EmployeeViewModel configured for editing an existing employee.
        /// </summary>
        /// <param name="employee">The employee being edited.</param>
        /// <param name="managerEmployee">The employee manager service.</param>
        public EmployeeViewModel(Employee employee, IManagerEmployee managerEmployee)
        {
            _employee = employee;
            _editMode = true;

            _managerEmployee = managerEmployee;
            SaveEmployeeCommand = new ViewModelCommand(ExecuteSaveEmployeeCommand);
        }

        #endregion


        #region Methods

        /// <summary>
        /// Executes when the save command is invoked.
        /// Determines whether a new employee should be created or an existing one updated.
        /// </summary>
        /// <param name="parameter">Command parameter (unused).</param>
        public void ExecuteSaveEmployeeCommand(object parameter)
        {
            if (_editMode == false)
            {
                // Create a new employee using the provided input fields
                Employee e = new Employee(
                    Name,
                    NIF,
                    PhoneNumber,
                    Email,
                    Role,
                    SalaryHour,
                    StartDate.Date);

                try
                {

                    bool success = _managerEmployee.CreateEmployee(e);
                    if (success)
                        HideWindowAction?.Invoke();
                }

                catch (ArgumentException ex)
                {

                    MessageBox.Show(ex.Message, "WARNING", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                catch(DataAccessException ex)
                {

                    MessageBox.Show(ex.Message, "WARNING", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            else if (_editMode == true)
            {

                try
                {

                    // Update the existing employee
                    bool success = _managerEmployee.UpdateEmployee(_employee);
                    if (success)
                        HideWindowAction?.Invoke();
                }

                catch(ArgumentException ex)
                {

                    MessageBox.Show(ex.Message, "WARNING", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                catch (DataAccessException ex)
                {

                    MessageBox.Show(ex.Message, "WARNING", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        #endregion
    }
}