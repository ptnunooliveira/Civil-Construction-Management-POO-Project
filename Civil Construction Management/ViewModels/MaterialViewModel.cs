using Civil_Construction_Management.Exceptions;
using Civil_Construction_Management.Models;
using Civil_Construction_Management.ViewModels.Interfaces;
using System.Windows;
using System.Windows.Input;

namespace Civil_Construction_Management.ViewModels
{
    /// <summary>
    /// ViewModel responsible for handling the creation of Materials
    /// and adding them to a specific project. This class represents
    /// the data binding layer for material creation windows.
    /// </summary>
    public class MaterialViewModel : BaseViewModel
    {

        #region Private Fields

        /// <summary>
        /// Backing field for the material being created or edited.
        /// </summary>
        private Material _material;

        /// <summary>
        /// Project manager service used to register the material in a project.
        /// </summary>
        private IManagerProject _managerProject;

        #endregion


        #region Public Properties

        /// <summary>
        /// Gets or sets the ID of the project associated with this material.
        /// When changed, notifies the UI.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the material name.
        /// Notifies UI on change.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the material quantity.
        /// Triggers UI update on modification.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the unit price of the material.
        /// Updates UI when changed.
        /// </summary>
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

        /// <summary>
        /// Action used to close the current window after saving.
        /// </summary>
        public Action? HideWindowAction { get; set; }

        /// <summary>
        /// Command that triggers material saving and associates it with a project.
        /// </summary>
        public ICommand SaveMaterialCommand { get; }

        #endregion


        #region Constructor

        /// <summary>
        /// Initializes a new instance of the MaterialViewModel with default values 
        /// and prepares the Save command.
        /// </summary>
        public MaterialViewModel(IManagerProject managerProject)
        {
            _material = new Material(string.Empty, 0, 0);
            _managerProject = managerProject;

            SaveMaterialCommand = new ViewModelCommand(ExecuteSaveCommand);
        }

        #endregion


        #region Methods

        /// <summary>
        /// Creates a new material instance with the provided data 
        /// and adds it to the target project using the manager service.
        /// If the operation succeeds, the window is closed.
        /// </summary>
        public void ExecuteSaveCommand(object parameter)
        {
            Material m = new Material(Name, Quantity, UnitPrice);
            m.ProjectID = ProjectID;

            try
            {
                bool success = _managerProject.AddMaterialToProject(ProjectID, m);                

                if(success)
                    HideWindowAction?.Invoke();
            }

            catch(ArgumentException e)
            {

                MessageBox.Show(e.Message, "WARNING", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            catch(DataAccessException e)
            {

                MessageBox.Show(e.Message, "WARNING", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        #endregion
    }
}