using Civil_Construction_Management.Models.Enums;

namespace Civil_Construction_Management.Models
{
    public class Employee
    {

        #region Private Fields

        private string _name;
        private string _nif;
        private string _phoneNumber;
        private string _email;
        private Roles _role;
        private double _salaryHour;
        private double _workHours;
        private DateTime _startDate;

        #endregion


        #region Public Properties

        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name can't be empty or null.");
                }

                if (value.Length > 100)
                {
                    throw new ArgumentException("Name can't be longer than 100 characters.");
                }

                _name = value;
            }
        }

        public string NIF
        {
            get => _nif;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("NIF can't be empty or null.");
                }

                if (value.Length != 9)
                {
                    throw new ArgumentException("NIF must be 9 characters long.");
                }

                _nif = value;
            }
        }

        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Phone Number can't empty or null.");
                }

                if (value.Length != 9)
                {
                    throw new ArgumentException("Phone Number must be 9 characters long.");
                }

                _phoneNumber = value;
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Email can't be empty or null.");
                }

                // Utilizar DLL para verificar se o email tem o @

                _email = value;
            }
        }

        public Roles Role
        {
            get => _role;
            set
            {
                if (value == default)
                {
                    throw new ArgumentException("Role can't be empty.");
                }

                if (Enum.IsDefined<Roles>(value))
                {
                    _role = value;
                }

                else
                {
                    throw new ArgumentException($"The {value} role is not a valid role.");
                }

            }
        }

        public double SalaryHour
        {
            get => _salaryHour;
            set
            {

                if (value < 4.94)
                {
                    throw new ArgumentException("Must be 4.94 or higher.");
                }

                _salaryHour = value;
            }
        }

        public double WorkHours
        {
            get => _workHours;
            set
            {
                if (value < 0 || value > 260)
                {
                    throw new ArgumentException("Error, please make sure the number of hours is right.");
                }

                _workHours = value;
            }
        }

        public DateTime StartDate
        {
            get => _startDate;
            set => _startDate = value;
        }

        #endregion


        #region Constructor

        public Employee(string name, string nif, string phoneNumber, string email, Roles role, double salaryHour, double workHours, DateTime startDate)
        {

            Name = name;
            NIF = nif;
            PhoneNumber = phoneNumber;
            Email = email;
            Role = role;
            SalaryHour = salaryHour;
            WorkHours = workHours;
            StartDate = startDate;
        }

        #endregion


        #region Methods

        public void AddHours(double todayHours)
        {
            if (todayHours < 0 || todayHours > 24)
            {
                throw new ArgumentException("It has to be a number between 0 and 24.");
            }

            WorkHours += todayHours;
        }

        public void SalaryIncrease(int percentage)
        {
            if (percentage < 0)
            {
                throw new ArgumentException("The percentage must be higher than 0.");
            }

            SalaryHour = SalaryHour + (SalaryHour * (percentage / 100));
        }

        // MELHORAR ESTA FUNÇÃO
        public void RoleUpgrade(string newRole)
        {
            if (string.IsNullOrEmpty(newRole))
            {
                throw new ArgumentException("New role can't be empty or null.");
            }
                     
            if (Enum.TryParse<Roles>(newRole, true, out Roles resultRole))
            {
                if (Role == resultRole)
                {
                    throw new ArgumentException($"The employee {Name} has already this role.");
                }

                Role = resultRole;
            }

            else
            {
                throw new ArgumentException($"The role {newRole} is not a valid role.");
            }
        }

        public double ProcessSalary()
        {

            return WorkHours * SalaryHour;
        }

        public void ShowInfo()
        {
            // Mostrar info do Funcionario
        }

        #endregion

    }
}
