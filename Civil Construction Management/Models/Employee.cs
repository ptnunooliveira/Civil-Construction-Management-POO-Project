namespace Civil_Construction_Management.Models
{
    /// <summary>
    /// Represents an employee working on a project, including identification,
    /// contact information, job details, and salary information.
    /// </summary>
    public class Employee
    {

        #region Private Fields

        private int _id;
        private int _projectID;
        private string _name;
        private string _nif;
        private string _phoneNumber;
        private string _email;
        private string _role;
        private double _salaryHour;
        private DateTime _startDate;

        #endregion


        #region Public Properties

        /// <summary>
        /// Gets or sets the unique identifier of the employee.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the ID of the project the employee is assigned to.
        /// </summary>
        public int ProjectID { get; set; }

        /// <summary>
        /// Gets or sets the employee's full name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the employee's NIF (tax identification number).
        /// </summary>
        public string NIF { get; set; }

        /// <summary>
        /// Gets or sets the employee's phone number.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the employee's email address.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the employee's role or job position.
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// Gets or sets the employee's hourly salary.
        /// </summary>
        public double SalaryHour { get; set; }

        /// <summary>
        /// Gets or sets the date the employee started working.
        /// </summary>
        public DateTime StartDate { get; set; }

        #endregion


        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Employee"/> class.
        /// </summary>
        /// <param name="name">Employee's full name.</param>
        /// <param name="nif">Employee's tax identification number (NIF).</param>
        /// <param name="phoneNumber">Employee's phone number.</param>
        /// <param name="email">Employee's email address.</param>
        /// <param name="role">Employee's job role.</param>
        /// <param name="salaryHour">Employee's hourly salary.</param>
        /// <param name="startDate">Start date of the employee's contract.</param>
        public Employee(string name, string nif, string phoneNumber, string email, string role, double salaryHour, DateTime startDate)
        {

            Name = name;
            NIF = nif;
            PhoneNumber = phoneNumber;
            Email = email;
            Role = role;
            SalaryHour = salaryHour;
            StartDate = startDate;
        }

        #endregion

    }
}
