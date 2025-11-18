using Civil_Construction_Management.Models;
using Civil_Construction_Management.ViewModel.MaterialFolder;
using System.Collections.ObjectModel;

namespace Civil_Construction_Management.ViewModel.WarehouseFolder
{
    public class WarehouseViewModel : BaseViewModel
    {
        private readonly Warehouse _warehouse;

        public int ID => _warehouse.ID;
        public string County => _warehouse.County;
        public string Employee => _warehouse.Employee.Name;
        public ObservableCollection<MaterialViewModel> Material { get; }
        

        public WarehouseViewModel(Warehouse warehouse)
        {
            _warehouse = warehouse;

            Material = new ObservableCollection<MaterialViewModel>(_warehouse.Materials.Select(m => new MaterialViewModel(m)));
        }
    }
}
