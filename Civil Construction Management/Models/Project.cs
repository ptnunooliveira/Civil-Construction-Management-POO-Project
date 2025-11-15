using Civil_Construction_Management.Enums;
using System.Collections.ObjectModel;

namespace Civil_Construction_Management.Models
{
    public class Project
    {
        private static int _currentID = 1;

        #region Private Fields

        private int _id;
        private string _clientName;
        private string _address;
        private Status _status;
        private Budget _budget;
        private ObservableCollection<Material> _materials;
        private ObservableCollection<Service> _services;
        private ObservableCollection<Employee> _employees;

        #endregion


        #region Public Properties

        public int ID { get => _id; }

        public string ClientName
        {
            get => _clientName;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Client Name can't be empty or null.");
                if (value.Length > 30)
                    throw new ArgumentException("Client Name must be lower than 30 characters.");

                _clientName = value;
            }
        }

        public string Address
        {
            get => _address;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Address can't be empty or null.");
                if (value.Length > 50)
                    throw new ArgumentException("Address must be lower than 50 characters.");

                _address = value;
            }
        }

        public Status Status
        {
            get => _status;
            set
            {
                if (value == default)
                {
                    throw new ArgumentException("Status can't be empty.");
                }

                if (!Enum.IsDefined<Status>(value))
                    throw new ArgumentException($"{value} is not a valid status.");

                _status = value;
            }
        }

        public Budget Budget
        {
            get => _budget;
            set
            {
                if (value == default)
                    throw new ArgumentException("Budget can't be empty.");

                _budget = value;
            }
        }

        public ObservableCollection<Material> Materials => _materials;
        public ObservableCollection<Service> Services => _services;
        public ObservableCollection<Employee> Employees => _employees;

        #endregion


        #region Constructor

        public Project(string clientName, string address, Status status, Budget budget)
        {
            ClientName = clientName;
            Address = address;
            Status = status;
            Budget = budget;

            _materials = new ObservableCollection<Material>();
            _services = new ObservableCollection<Service>();
            _employees = new ObservableCollection<Employee>();

            _id = _currentID++;
        }

        #endregion


        #region Methods



        #endregion
    }
}
