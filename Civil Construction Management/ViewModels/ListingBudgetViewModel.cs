using System.Collections.ObjectModel;

namespace Civil_Construction_Management.ViewModels;

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
