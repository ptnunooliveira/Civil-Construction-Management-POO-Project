using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Civil_Construction_Management.Models
{
    public class Material
    {

        private static int _currentID = 1;

        #region Private Fields

        private int _id;
        private string _name;
        private int _quantity;
        private double _unitPrice;

        #endregion


        #region Public Properties

        public int ID { get; }

        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name can't be empty or null.");
                }

                if (value.Length > 50)
                {
                    throw new ArgumentException("Name can't be longer than 50 characters.");
                }

                _name = value;
            }
        }

        public int Quantity
        {
            get => _quantity;
            set
            {
                if (value == default)
                {
                    throw new ArgumentException("Quantity can't be empty");
                }

                if (value < 0)
                {
                    throw new ArgumentException("Negative numbers are not valid.");
                }
            }
        }

        public double UnitPrice
        {
            get => _unitPrice;
            set
            {
                if (value == default)
                {
                    throw new ArgumentException("Unit price can't be empty.");
                }

                if (value <= 0)
                {
                    throw new ArgumentException("Unit price must be higher than 0€.");
                }
            }
        }

        #endregion


        #region Constructor

        public Material(string name, int quantity, double unitPrice)
        {
            Name = name;
            Quantity = quantity;
            UnitPrice = unitPrice;

            _id = _currentID++;
        }

        #endregion


        #region Methods

        public void QuantityUpdate(int howMuch)
        {
            if (howMuch == default)
                throw new ArgumentException("Error, please check the value.");

            if (howMuch <= 0)
                throw new ArgumentException("You can't add a negative number or zero.");

            Quantity += howMuch;
        }

        public void CheckQuantity()
        {
            // Ver quantidade
        }

        public void UpdateUnitPrice(double newUnitPrice)
        {
            if(newUnitPrice == default)
                throw new ArgumentException("Error, please check the value.");

            if (newUnitPrice <= 0)
                throw new ArgumentException($"{Name}'s unity price must be positive.");

            UnitPrice = newUnitPrice;
        }

        public void ViewDescription()
        {

        }

        #endregion

    }
}
