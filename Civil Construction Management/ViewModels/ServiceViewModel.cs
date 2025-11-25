using Civil_Construction_Management.Models;

namespace Civil_Construction_Management.ViewModels
{
    public class ServiceViewModel : BaseViewModel
    {

        private readonly Service _service;

        public int ID => _service.ID;
        public string CompanyName => _service.CompanyName.ToString();
        public double ServiceHours => _service.ServiceHours;
        public string Status => _service.Status.ToString();
        public DateTime StartDate => _service.StartDate;
        public DateTime EndDate => _service.EndDate;


        public ServiceViewModel(Service service)
        {
            _service = service;
        }

    }
}
