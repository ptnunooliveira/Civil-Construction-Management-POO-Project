using Civil_Construction_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Civil_Construction_Management.ViewModel.BudgetFolder
{
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
}
