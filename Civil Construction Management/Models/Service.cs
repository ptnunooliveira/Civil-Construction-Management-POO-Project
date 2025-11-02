using Civil_Construction_Management.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Civil_Construction_Management.Models
{
    public class Service
    {

        private static int _currentID = 1;


        #region Private Fields

        private int _id;
        private Subcontractor _companyName;
        private double _serviceHours;
        private Status _status;
        private DateTime _startDate;
        private DateTime _endDate;

        #endregion


        #region Public Properties

        public int ID { get; }

        public Subcontractor CompanyName
        {
            get => _companyName;
            set
            {
                if (value == default)
                {
                    throw new ArgumentException("Company's name can't be empty.");
                }

                // Procurar na lista de Subcontratados da classe Organization 
                //foreach(var in )
                //_companyName = value;
            }
        }

        public double ServiceHours
        {
            get => _serviceHours;
            set
            {
                if (value == default)
                {
                    throw new ArgumentException("Service hours can't be empty.");
                }

                if (value < 0)
                {
                    throw new ArgumentException("Negative hours are not valid.");
                }

                _serviceHours = value;
            }
        }

        public Status Status
        {
            get => _status;
            set
            {
                if (value == default)
                {
                    throw new ArgumentException("Status can't be empty.");
                }

                if (Enum.IsDefined<Status>(value))
                {
                    _status = value;
                }

                else
                {
                    throw new ArgumentException($"The status {value} is not a valid status.");
                }
            }
        }

        public DateTime StartDate
        {
            get => _startDate;
            set
            {
                if (value == default)
                {
                    throw new ArgumentException("StartDate can´t be empty");
                }

                if (value <= DateTime.Today)
                {
                    throw new ArgumentException("Start Date is not valid.");
                }

                _startDate = value;
            }
        }

        public DateTime EndDate
        {
            get => _endDate;
            set
            {
                Enum.TryParse<Status>("Finished", true, out Status result);

                if (Status != result)
                {
                    throw new ArgumentException("The service is not finished yet.");
                }

                if (value > DateTime.Today || value < StartDate)
                {
                    throw new ArgumentException("End Date is not valid.");
                }

                _endDate = value;
            }
        }

        #endregion


        #region Constructor

        public Service(Subcontractor companyName, double serviceHours, Status status, DateTime startDate, DateTime endDate)
        {
            CompanyName = companyName;
            ServiceHours = serviceHours;
            Status = status;
            StartDate = startDate;
            EndDate = endDate;

            _id = _currentID++;
        }

        #endregion


        #region Methods

        public int DurationTime()
        {

            int days = 0;

            if (DateTime.Now < StartDate)
            {
                throw new ArgumentException("The service is yet to start.");
            }

            if (DateTime.Now > StartDate && EndDate == default)
            {
                TimeSpan result = DateTime.Today - StartDate;

                days = result.Days;

            }

            else if (DateTime.Now > StartDate && EndDate != default)
            {
                TimeSpan result = EndDate - StartDate;

                days = result.Days;
            }

            else
            {
                throw new ArgumentException("It was not possible to give the duration of the service.");
            }

            return days;
        }


        public void ChangeStatus(string newStatus)
        {

            if (string.IsNullOrEmpty(newStatus))
            {
                throw new ArgumentException("New status can't be empty or null.");
            }

            if (Enum.TryParse<Status>(newStatus, true, out Status result))
            {
                if (Status == result)
                {
                    throw new ArgumentException($"The service {ID} has already the {Status} status.");
                }

                Status = result;
            }

            else
            {
                throw new ArgumentException("That status is not valid.");
            }

        }

        public double TotalCost()
        {
            return ServiceHours * CompanyName.CostHour;
        }

        #endregion
    }
}
