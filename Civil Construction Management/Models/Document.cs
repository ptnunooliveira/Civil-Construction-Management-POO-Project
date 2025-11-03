using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Civil_Construction_Management.Enums;

namespace Civil_Construction_Management.Models
{
    public abstract class Document
    {

        #region Private Fields

        private TypeOfDocuments _typeOfDocument;
        private DateTime _emissionDate;

        #endregion


        #region Public Properties

        public TypeOfDocuments TypeOfDocument
        {
            get => _typeOfDocument;
            set
            {
                if (value == default)
                    throw new ArgumentException("Type of document empty or invalid.");

                if (Enum.IsDefined<TypeOfDocuments>(value))
                    _typeOfDocument = value;

                else
                    throw new ArgumentException("That type of document is not valid.");
            }
        }

        public DateTime EmissionDate { get => _emissionDate; }

        #endregion


        #region Constuctor

        public Document(TypeOfDocuments typeOfDocument)
        {

            TypeOfDocument = typeOfDocument;
            _emissionDate = DateTime.Now;
        }

        #endregion


        #region Methods

        // Ver resumo

        #endregion
    }
}
