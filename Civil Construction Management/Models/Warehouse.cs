using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Civil_Construction_Management.Models
{
    public class Warehouse
    {
        private static int _currentID = 1;

        #region Private Fields

        private int _id;
        private string _county;
        private List<Material> _materials;
        private Employee _employee;

        #endregion

        #region Public Properties

        public int ID { get; }

        public string County
        {
            get => _county;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("County can't be empty.");
                }

                if (value.Length > 30)
                {
                    throw new ArgumentException("County can't be longer than 30 characters.");
                }

                _county = value;
            }
        }

        #endregion

        #region Constructor

        public Warehouse(string county)
        {
            County = county;
            _materials = new List<Material>();

            _id = _currentID++;
        }

        #endregion


        #region Methods

        public void AddMaterial()
        {

        }

        #endregion
    }
}
