using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Civil_Construction_Management.ViewModel.BudgetFolder
{
    public class ListingBudgetViewModel : BaseViewModel
    {

        private ObservableCollection<BudgetViewModel> _budgets;

        public ObservableCollection<BudgetViewModel> Budgets => _budgets;


        //COMMANDS
        //

        public ListingBudgetViewModel()
        {
            _budgets = new ObservableCollection<BudgetViewModel>();
        }
    }
}
