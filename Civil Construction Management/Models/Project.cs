namespace Civil_Construction_Management.Models
{
    public class Project
    {

        #region Private Fields

        private string _clientName;
        private string _address;
        private string _status;
        private IEnumerable<Material> _materials;
        private IEnumerable<Service> _services;
        private IEnumerable<Employee> _employees;

        #endregion


        #region Public Properties

        public string ClientName { get; set; }

        public string Address { get; set; }

        public string Status { get; set; }
        

        public IEnumerable<Material> Materials => _materials;
        public IEnumerable<Service> Services => _services;
        public IEnumerable<Employee> Employees => _employees;

        #endregion


        #region Constructor

        public Project(string clientName, string address, string status)
        {
            ClientName = clientName;
            Address = address;
            Status = status;

            _materials = new List<Material>();
            _services = new List<Service>();
            _employees = new List<Employee>();
        }

        #endregion
    }
}
