using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Civil_Construction_Management.Enums;

namespace Civil_Construction_Management.Models
{
    public class Budget : Document
    {

        private static int _currentID = 1;

        #region Private Fields

        private int _id;
        private double _totalCost;

        #endregion


        #region Public Properties

        public int ID { get => _id; }
        public double TotalCost { get => _totalCost; }

        #endregion


        #region Constructor

        public Budget(TypeOfDocuments typeOfDocument) : base(typeOfDocument)
        {
            _id = _currentID++;
        }

        #endregion


        #region Methods

        // Falta métodos

        #endregion
    }
}
