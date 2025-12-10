namespace Civil_Construction_Management.Models
{
    public class Service
    {

        #region Public Properties

        public int ProjectID { get; set; }

        public string CompanyName{ get; set; }

        public double ServiceHours{ get; set; }

        public string Status{ get; set; }

        public DateTime StartDate{ get; set; }

        public DateTime EndDate{ get; set; }

        #endregion


        #region Constructor

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
