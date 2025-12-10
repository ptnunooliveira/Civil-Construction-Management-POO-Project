namespace Civil_Construction_Management.Models
{
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

        public int ID { get; set; }

        public int ProjectID { get; set; }
        
        public string Name { get; set; }
        
        public string NIF { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }
        
        public double SalaryHour { get; set; }

        public DateTime StartDate { get; set; }

        #endregion


        #region Constructor

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


        #region Methods

        #endregion

    }
}
