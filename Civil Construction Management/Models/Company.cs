using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Civil_Construction_Management.Models
{
    public abstract class Company
    {

        #region Private Fields

        private string _name;
        private string _nif;
        private string _address;
        private DateTime _foundationDate;

        #endregion


        #region Public Properties

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
                    throw new ArgumentException("Subcontractor's name can't be longer than 50 characters");
                }

                _name = value;
            }
        }

        public string NIF
        {
            get => _nif;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("NIF can't be empty or null.");
                }

                if (value.Length != 9)
                {
                    throw new ArgumentException("NIF must have 9 digits.");
                }

                _nif = value;
            }
        }

        public string Address
        {
            get => _address;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Address can't be empty.");
                }

                if(value.Length > 100)
                {
                    throw new ArgumentException("Address can't be longer than 100 characters.");
                }

                _address = value;
            }
        }

        public DateTime FoundationDate
        {
            get => _foundationDate;
            set
            {
                if (value == default)
                {
                    throw new ArgumentException("Foundation date can't be empty.");
                }

                _foundationDate = value;
            }
        }

        #endregion


        #region Constructor

        public Company(string name, string nif, string address, DateTime foundationDate)
        {
            Name = name;
            NIF = nif;
            Address = address;
            FoundationDate = foundationDate;
        }

        #endregion


        #region Methods

        public virtual void ShowInfo()
        {
            // Mostra Info da Empresa
        }

        #endregion
    }
}
