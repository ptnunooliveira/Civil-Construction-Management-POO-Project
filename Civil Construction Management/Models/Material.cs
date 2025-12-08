namespace Civil_Construction_Management.Models
{
    public class Material
    {

        #region Private Fields

        private int _projectID;
        private string _name;
        private int _quantity;
        private double _unitPrice;

        #endregion


        #region Public Properties

        public int ProjectID { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public double UnitPrice { get; set; }

        #endregion


        #region Constructor

        public Material(string name, int quantity, double unitPrice)
        {

            Name = name;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }

        #endregion
    }
}