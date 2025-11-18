using System.Collections.ObjectModel;

namespace Civil_Construction_Management.ViewModel.ServiceFolder
{
    public class ListingServiceViewModel : BaseViewModel
    {

        private ObservableCollection<ServiceViewModel> _services;

        public ObservableCollection<ServiceViewModel> Services => _services;

        //COMMANDS
        //

        public ListingServiceViewModel()
        {
            _services = new ObservableCollection<ServiceViewModel>();
        }
    }
}
