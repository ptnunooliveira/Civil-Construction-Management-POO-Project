using System.Collections.ObjectModel;

namespace Civil_Construction_Management.ViewModels
{
    public class ListingMaterialViewModel : BaseViewModel
    {
        private readonly ObservableCollection<MaterialViewModel> _materials;

        public ObservableCollection<MaterialViewModel> Materials => _materials;

        //Commands

        //

        public ListingMaterialViewModel()
        {
            _materials = new ObservableCollection<MaterialViewModel>();
        }
    }
}
