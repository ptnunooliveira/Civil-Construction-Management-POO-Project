namespace Civil_Construction_Management.Models
{
    /// <summary>
    /// Represents a material associated with a project, storing its name,
    /// quantity, and unit price for cost calculations.
    /// </summary>
    public class Material
    {

        #region Private Fields

        private int _projectID;
        private string _name;
        private int _quantity;
        private double _unitPrice;

        #endregion


        #region Public Properties

        /// <summary>
        /// Gets or sets the ID of the project this material belongs to.
        /// </summary>
        public int ProjectID { get; set; }

        /// <summary>
        /// Gets or sets the material name (e.g., cement, bricks, steel).
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the quantity required for the project.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the material's unit price.
        /// </summary>
        public double UnitPrice { get; set; }

        #endregion


        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Material"/> class.
        /// </summary>
        /// <param name="name">Material name.</param>
        /// <param name="quantity">Quantity of the material.</param>
        /// <param name="unitPrice">Price per unit of the material.</param>
        public Material(string name, int quantity, double unitPrice)
        {

            Name = name;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }

        #endregion
    }
}