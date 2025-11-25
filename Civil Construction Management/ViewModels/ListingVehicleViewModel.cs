using System.Collections.ObjectModel;

namespace Civil_Construction_Management.ViewModels
{
    public class ListingVehicleViewModel : BaseViewModel
    {

        private readonly ObservableCollection<VehicleViewModel> _vehicles;

        public ObservableCollection<VehicleViewModel> Vehicles => _vehicles;

        //public ICommand AddVehicleCommand { get; }
        //public ICommand RemoveVehicleCommand { get; }
        //public ICommand GoToEmployee_VehicleCommand { get; }

        public ListingVehicleViewModel()
        {
            _vehicles = new ObservableCollection<VehicleViewModel>();
        }
    }
}
