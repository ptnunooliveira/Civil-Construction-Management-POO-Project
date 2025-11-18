using Civil_Construction_Management.Models;
using Civil_Construction_Management.ViewModel.BudgetFolder;
using Civil_Construction_Management.ViewModel.EmployeeFolder;
using Civil_Construction_Management.ViewModel.ProjectsFolder;
using Civil_Construction_Management.ViewModel.SubcontractorFolder;
using Civil_Construction_Management.ViewModel.VehicleFolder;
using Civil_Construction_Management.ViewModel.WarehouseFolder;
using System.Collections.ObjectModel;

namespace Civil_Construction_Management.ViewModel
{
    public class OrganizationViewModel : BaseViewModel
    {

        private readonly Organization _organization;

        public string CEO => _organization.CEO.ToString();

        public ObservableCollection<BudgetViewModel> Budgets { get; }
        public ObservableCollection<EmployeeViewModel> Employees { get; }
        public ObservableCollection<ProjectViewModel> Projects { get; }
        public ObservableCollection<SubcontractorViewModel> Subcontractors { get; }
        public ObservableCollection<VehicleViewModel> Vehicles { get; }
        public ObservableCollection<WarehouseViewModel> Warehouses { get; }


        public OrganizationViewModel(Organization organization)
        {
            _organization = organization;

            Budgets = new ObservableCollection<BudgetViewModel>(_organization.Budgets.Select(b => new BudgetViewModel(b)));
            Employees = new ObservableCollection<EmployeeViewModel>(_organization.Employees.Select(e => new EmployeeViewModel(e)));
            Projects = new ObservableCollection<ProjectViewModel>(_organization.Projects.Select(p => new ProjectViewModel(p)));
            Subcontractors = new ObservableCollection<SubcontractorViewModel>(_organization.Subcontractors.Select(s => new SubcontractorViewModel(s)));
            Vehicles = new ObservableCollection<VehicleViewModel>(_organization.Vehicles.Select(v => new VehicleViewModel(v)));
            Warehouses = new ObservableCollection<WarehouseViewModel>(_organization.Warehouses.Select(w => new WarehouseViewModel(w)));
        }


    }
}
