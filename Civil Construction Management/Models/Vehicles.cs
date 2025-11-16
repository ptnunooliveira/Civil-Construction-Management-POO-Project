using Civil_Construction_Management.Enums;

namespace Civil_Construction_Management.Models
{
    public class Vehicle
    {

        #region Private Fields

        private string _vin;
        private CarBrand _brand;
        private string _model;
        private CarColor _color;
        private double _kmLastOilChange;
        private DateTime _lastOilChange;
        private DateTime _lastInspection;

        #endregion


        #region Public Properties

        public string VIN
        {
            get => _vin;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("VIN can't be empty or null.");

                if (value.Length != 17)
                    throw new ArgumentException("VIN must be 17 digits long.");

                _vin = value;
            }   
        }

        public CarBrand Brand
        {
            get => _brand;
            set
            {
                if (value == default)
                    throw new ArgumentException("Brand can't be empty.");

                if (Enum.IsDefined<CarBrand>(value))
                    _brand = value;

                else
                    throw new ArgumentException($"{value} is not a valid brand.");
            }
        }

        public string Model
        {
            get => _model;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Brand can't be empty or null.");

                if (value.Length > 15)
                    throw new ArgumentException("Max 15 characters.");

                _model = value;
            }
        }

        public CarColor Color
        {
            get => _color;
            set
            {
                if (value == default)
                    throw new ArgumentException("Color can't be empty.");

                if (Enum.IsDefined<CarColor>(value))
                    _color = value;

                else
                    throw new ArgumentException($"{value} is not a valid color.");
            }
        }

        public double KmLastOilChange
        {
            get => _kmLastOilChange;
            set
            {
                if (value < 0 || value < KmLastOilChange || value == default)
                    throw new ArgumentException("Wrong number.");

                _kmLastOilChange = value;
            }
        }

        public DateTime LastOilChange
        {
            get => _lastOilChange;
            set
            {
                if (value > DateTime.Now || value < LastOilChange || value == default)
                    throw new ArgumentException("Wrong date.");

                _lastOilChange = value;
            }
        }

        public DateTime LastInspection
        {
            get => _lastInspection;
            set
            {
                if (value > DateTime.Now || value < LastInspection || value == default)
                    throw new ArgumentException("Wrong date.");

                _lastInspection = value;
            }
        }

        #endregion


        #region Constructor

        public Vehicle(string vin, CarBrand brand, string model, CarColor color)
        {
            VIN = vin;
            Brand = brand;
            Model = model;
            Color = color;
        }

        #endregion


        #region Methods

        public void AddLastOilChange(DateTime dt)
        {
            LastOilChange = dt;
        }

        public void AddLastInspection(DateTime dt)
        {
            LastInspection = dt;
        }

        public void AddKmLastOilChange(double km)
        {
            KmLastOilChange = km;
        }

        // Metodos para mostrar datas

        #endregion
    }
}
