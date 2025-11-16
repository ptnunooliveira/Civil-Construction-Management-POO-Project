namespace Civil_Construction_Management.Models
{
    public class Warehouse
    {
        private static int _currentID = 1;

        #region Private Fields

        private int _id;
        private string _county;
        private List<Material> _materials;
        private Employee _employee;

        #endregion


        #region Public Properties

        public int ID { get; }

        public string County
        {
            get => _county;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("County can't be empty.");
                }

                if (value.Length > 30)
                {
                    throw new ArgumentException("County can't be longer than 30 characters.");
                }

                _county = value;
            }
        }

        public List<Material> Materials => _materials;
        public Employee Employee => _employee;

        #endregion


        #region Constructor

        public Warehouse(string county)
        {
            County = county;
            _materials = new List<Material>();

            _id = _currentID++;
        }

        #endregion


        #region Methods

        public void AddMaterial(Material m)
        {
            if (m == null)
                throw new ArgumentException("Material can't be null.");

            // Fazer DLL para ver se há repetido. 

            _materials.Add(m);
        }
                
        public void ElectEmployee(Employee e)
        {

            if (e == null)
                throw new ArgumentException("Employee can't be null.");

            // Fazer DLL para procurar numa lista para ver se existe. 

        }

        public void CheckStock(Material m)
        {

            if (m == null)
                throw new ArgumentException("Material can't be null");

            // Fazer DLL para procurar numa lista para ver se existe.

            
        }

        public double StockValue()
        {
            double total = 0;

            foreach(Material m in _materials)
                total += (m.UnitPrice * m.Quantity);

            return total;
        }


        #endregion

    }
}
