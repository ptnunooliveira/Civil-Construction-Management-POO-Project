using System.Collections.ObjectModel;

namespace Civil_Construction_Management.ViewModel.SubcontractorFolder
{
    public class ListingSubcontractorViewModel : BaseViewModel
    {

        private ObservableCollection<SubcontractorViewModel> _subcontractor;

        public ObservableCollection<SubcontractorViewModel> Subcontractor => _subcontractor;

        //COMMANDS
        //

        public ListingSubcontractorViewModel()
        {
            _subcontractor = new ObservableCollection<SubcontractorViewModel>();
        }
    }
}
