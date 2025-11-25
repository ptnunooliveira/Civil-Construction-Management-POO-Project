using Civil_Construction_Management.Models;

namespace Civil_Construction_Management.ViewModels
{
    public class VehicleViewModel : BaseViewModel
    {

        private readonly Vehicle _vehicle;

        public string VIN => _vehicle.VIN;
        public string Brand => _vehicle.Brand.ToString();
        public string Model => _vehicle.Model;
        public string Color => _vehicle.Color.ToString();
        public double KmLastOilChange => _vehicle.KmLastOilChange;
        public DateTime LastOilChange => _vehicle.LastOilChange;
        public DateTime LastInspection => _vehicle.LastInspection;


        public VehicleViewModel(Vehicle vehicle)
        {
            _vehicle = vehicle;
        }
    }
}
