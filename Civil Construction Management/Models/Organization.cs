using System.Collections.ObjectModel;

namespace Civil_Construction_Management.Models
{
    public class Organization : Company
    {

        #region Private Fields

        private Employee _ceo;
        private ObservableCollection<Project> _projects;
        private ObservableCollection<Warehouse> _warehouses;
        private ObservableCollection<Vehicle> _vehicles;
        private ObservableCollection<Budget> _budgets;
        private ObservableCollection<Employee> _employees;
        private ObservableCollection<Subcontractor> _subcontractors;

        #endregion


        #region Public Properties
        
        public Employee CEO
        {
            get => _ceo;
            set
            {
                // DDL para procurar numa lista e verificar se existe um igual
            }
        }

        public ObservableCollection<Project> Projects;
        public ObservableCollection<Warehouse> Warehouses;
        public ObservableCollection<Vehicle> Vehicles;
        public ObservableCollection<Budget> Budgets;
        public ObservableCollection<Employee> Employees;
        public ObservableCollection<Subcontractor> Subcontractors;

        #endregion

        #region Constructor

        public Organization(string name, string nif, string address, DateTime foundationDate, Employee ceo) : base(name, nif, address, foundationDate)
        {
            CEO = ceo;

            Projects = new ObservableCollection<Project>();
            Warehouses = new ObservableCollection<Warehouse>();
            Vehicles = new ObservableCollection<Vehicle>();
            Budgets = new ObservableCollection<Budget>();
            Employees = new ObservableCollection<Employee>();
            Subcontractors = new ObservableCollection<Subcontractor>();
        }

        #endregion
    }
}
