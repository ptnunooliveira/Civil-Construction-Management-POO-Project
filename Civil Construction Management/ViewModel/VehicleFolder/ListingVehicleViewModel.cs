using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Civil_Construction_Management.ViewModel.VehicleFolder
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
