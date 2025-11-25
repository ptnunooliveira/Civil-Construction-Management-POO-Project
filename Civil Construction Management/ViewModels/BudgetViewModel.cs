using Civil_Construction_Management.Models;

namespace Civil_Construction_Management.ViewModels;

public class BudgetViewModel : BaseViewModel
{
    private readonly Budget _budget;

    public int ID => _budget.ID;
    public double TotalCost => _budget.TotalCost;


    public BudgetViewModel(Budget budget)
    {
        _budget = budget;
    }

}
