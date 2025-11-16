using Civil_Construction_Management.Enums;

namespace Civil_Construction_Management.Models
{

    // FALTA MÉTODOS
    public class Subcontractor : Company
    {

        private static int _currentID = 1;

        #region Private Fields

        private int _id;
        private double _costHour;
        private TypeOfServices _typeOfService;

        #endregion


        #region Public Properties

        public int ID { get; }

        public double CostHour
        {
            get => _costHour;
            set
            {
                if (value < 4.94)
                {
                    throw new ArgumentException("The value must be 4.94 or higher.");
                }

                _costHour = value;
            }
        }

        public TypeOfServices TypeOfService
        {
            get => _typeOfService;
            set
            {
                if (value == default)
                {
                    throw new ArgumentException("Type of service can't be empty.");
                }

                if (Enum.IsDefined<TypeOfServices>(value))
                {
                    _typeOfService = value;
                }

                else
                {
                    throw new ArgumentException("Type of service invalid.");
                }
            }
        }

        #endregion


        #region Constructor

        public Subcontractor(double costHour, TypeOfServices typeOfService, string name, string nif, string address, DateTime foundationDate)
            : base(name, nif, address, foundationDate)
        {
            
            CostHour = costHour;
            TypeOfService = typeOfService;

            _id = _currentID++;
        }

        #endregion


        #region Methods

        #endregion
    }
}
