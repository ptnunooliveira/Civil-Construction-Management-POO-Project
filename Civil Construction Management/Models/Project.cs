using System.Collections.ObjectModel;

namespace Civil_Construction_Management.Models
{
    public class Project
    {

        #region Private Fields

        private int _id;
        private string _clientName;
        private string _address;
        private string _status;

        #endregion


        #region Public Properties

        public int ID { get; set; }

        public string ClientName { get; set; }

        public string Address { get; set; }

        public string Status { get; set; }
        

        public ObservableCollection<Material> Materials{ get; set; }
        public ObservableCollection<Service> Services { get; set; }
        public ObservableCollection<Employee> Employees { get; set; }

        #endregion


        #region Constructor

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
