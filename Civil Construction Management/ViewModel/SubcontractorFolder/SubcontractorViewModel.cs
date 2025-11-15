using Civil_Construction_Management.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Civil_Construction_Management.ViewModel.SubcontractorFolder
{
    public class SubcontractorViewModel : BaseViewModel
    {

        private readonly Subcontractor _subcontractor;

        public int ID => _subcontractor.ID;
        public double CostHour => _subcontractor.CostHour;
        public string TypeOfService => _subcontractor.TypeOfService.ToString();


        public SubcontractorViewModel(Subcontractor subcontractor)
        {
            _subcontractor = subcontractor;
        }
    }
}
