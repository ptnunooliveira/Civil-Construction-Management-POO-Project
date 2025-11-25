using Civil_Construction_Management.Models;

namespace Civil_Construction_Management.ViewModels
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
