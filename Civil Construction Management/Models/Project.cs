using System.Collections.ObjectModel;

namespace Civil_Construction_Management.Models
{
    /// <summary>
    /// Represents a construction project that stores client details,
    /// address, current status, and lists of associated materials,
    /// services, and employees.
    /// </summary>
    public class Project
    {

        #region Private Fields

        private int _id;
        private string _clientName;
        private string _address;
        private string _status;

        #endregion


        #region Public Properties

        /// <summary>
        /// Gets or sets the project's unique identifier.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the client's name responsible for the project.
        /// </summary>
        public string ClientName { get; set; }

        /// <summary>
        /// Gets or sets the address where the project is located.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the current status of the project
        /// (e.g., Pending, In Progress, Completed).
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Holds all materials associated with this project.
        /// </summary>
        public ObservableCollection<Material> Materials { get; set; }

        /// <summary>
        /// Holds all services assigned to this project (external companies, contractors, etc.).
        /// </summary>
        public ObservableCollection<Service> Services { get; set; }

        /// <summary>
        /// Holds all employees assigned to this project.
        /// </summary>
        public ObservableCollection<Employee> Employees { get; set; }

        #endregion


        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Project"/> class
        /// with the provided client name, address, and status.
        /// </summary>
        /// <param name="clientName">Name of the client requesting the project.</param>
        /// <param name="address">Project location.</param>
        /// <param name="status">Current project status.</param>
        public Project(string clientName, string address, string status)
        {
            ClientName = clientName;
            Address = address;
            Status = status;

            Materials = new ObservableCollection<Material>();
            Services = new ObservableCollection<Service>();
            Employees = new ObservableCollection<Employee>();
        }

        #endregion
    }
}