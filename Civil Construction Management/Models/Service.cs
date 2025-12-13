namespace Civil_Construction_Management.Models
{
    /// <summary>
    /// Represents a service provided by an external company to a project,
    /// including service hours, status, and the start/end dates.
    /// </summary>
    public class Service
    {

        #region Public Properties

        /// <summary>
        /// Gets or sets the ID of the project this service belongs to.
        /// </summary>
        public int ProjectID { get; set; }

        /// <summary>
        /// Gets or sets the name of the company providing the service.
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets the number of hours worked by the service provider.
        /// </summary>
        public double ServiceHours { get; set; }

        /// <summary>
        /// Gets or sets the current status of the service 
        /// (e.g., Pending, In Progress, Completed).
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the date when the service started.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets the date when the service ended.
        /// </summary>
        public DateTime EndDate { get; set; }

        #endregion


        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Service"/> class.
        /// </summary>
        /// <param name="companyName">Name of the service provider company.</param>
        /// <param name="serviceHours">Total hours worked.</param>
        /// <param name="status">Current status of the service.</param>
        /// <param name="startDate">Service start date.</param>
        /// <param name="endDate">Service end date.</param>
        public Service(string companyName, double serviceHours, string status, DateTime startDate, DateTime endDate)
        {

            CompanyName = companyName;
            ServiceHours = serviceHours;
            Status = status;
            StartDate = startDate;
            EndDate = endDate;
        }

        #endregion                
    }
}