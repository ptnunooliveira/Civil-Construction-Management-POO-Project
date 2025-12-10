using Civil_Construction_Management.Models;
using Civil_Construction_Management.ViewModels.Interfaces;
using System.Windows.Input;

namespace Civil_Construction_Management.ViewModels
{
    public class MaterialViewModel : BaseViewModel
    {

        #region Private Fields

        private Material _material;
        private IManagerProject _managerProject;

        #endregion


        #region Public Properties

        public int ProjectID
        {
            get => _material.ProjectID;
            set
            {
                if (_material.ProjectID != value)
                {
                    _material.ProjectID = value;
                    OnPropertyChanged(nameof(ProjectID));
                }
            }
        }

        public string Name
        {
            get => _material.Name;
            set
            {
                if (_material.Name != value)
                {
                    _material.Name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        public int Quantity
        {
            get => _material.Quantity;
            set
            {
                if (_material.Quantity != value)
                {
                    _material.Quantity = value;
                    OnPropertyChanged(nameof(Quantity));
                }
            }
        }

        public double UnitPrice
        {
            get => _material.UnitPrice;
            set
            {
                if (_material.UnitPrice != value)
                {
                    _material.UnitPrice = value;
                    OnPropertyChanged(nameof(UnitPrice));
                }
            }
        }

        public Action? HideWindowAction { get; set; }
        public ICommand SaveMaterialCommand { get; }

        #endregion


        #region Constructor

        public MaterialViewModel(IManagerProject managerProject)
        {

            _material = new Material(string.Empty, 0, 0);
            _managerProject = managerProject;

            SaveMaterialCommand = new ViewModelCommand(ExecuteSaveCommand);
        }

        #endregion


        #region Methods

        public void ExecuteSaveCommand(object parameter)
        {

            Material m = new Material(Name, Quantity, UnitPrice);
            m.ProjectID = ProjectID;

            bool success = _managerProject.AddMaterialToProject(ProjectID, m);
            if (!success)
                return;

            HideWindowAction?.Invoke();
        }

        #endregion
    }
}
