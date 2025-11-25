using Civil_Construction_Management.ViewModel.Interfaces;
using Civil_Construction_Management.ViewModels;
using System.Windows.Controls;

namespace Civil_Construction_Management.Views.MainViews
{
    
    public partial class EmployeeView : UserControl
    {
        private readonly ListingEmployeeViewModel _listingEmployee;
        private readonly IManagerEmployee m;
     
        public EmployeeView(IManagerEmployee M)
        {
            
            InitializeComponent();
            m = M;
            _listingEmployee = new ListingEmployeeViewModel(m);
            //_listingEmployee.HideWindowAction = Hide;
            DataContext = _listingEmployee;
        }
    }
}
