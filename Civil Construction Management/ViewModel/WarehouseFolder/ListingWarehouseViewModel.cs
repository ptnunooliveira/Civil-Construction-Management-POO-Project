using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Civil_Construction_Management.ViewModel.WarehouseFolder
{
    public class ListingWarehouseViewModel : BaseViewModel
    {

        private readonly ObservableCollection<WarehouseViewModel> _warehouses;

        public ObservableCollection<WarehouseViewModel> Warehouses => _warehouses;

        //public ICommand AddWarehouseCommand { get; }
        //public ICommand RemoveWarehouseCommand { get; }
        //public ICommand GoToEmployee_WarehouseCommand { get; }


        public ListingWarehouseViewModel()
        {
            _warehouses = new ObservableCollection<WarehouseViewModel>();
        }

    }
}
