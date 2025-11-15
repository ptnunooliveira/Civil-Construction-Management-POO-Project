using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Civil_Construction_Management.ViewModel.MaterialFolder
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
