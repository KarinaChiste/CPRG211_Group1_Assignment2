using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPRG211_Group1_Assignment2.Exceptions;


namespace CPRG211_Group1_Assignment2.Classes
{
    public class Reservation : Flight
    {
        private bool status;
        public string ReservationCode { get; set; }

        private string fullName;

        public string FullName
        {
            get => fullName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new EmptyFieldException("FullName cannot be empty or whitespace.");
                }
                fullName = value;
            }
        }

        private string citizenship;
        public string Citizenship
        {
            get => citizenship;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new EmptyFieldException("Citizenship cannot be empty or whitespace.");
                }
                citizenship = value;
            }
        }

        public string Status { get; set; }

        public bool Status {  get { return status; } set { status = value; } }
        public Reservation(string flightCode, string airline, string originAirport, string destAirport,
            string day, string departureTime, int capacity, string price, string reservationCode, string fullName, string citizenship, string status = "Active") : 
            base(flightCode, airline, originAirport, destAirport, day, departureTime, capacity, price)
        {
           if (flightCode == null)
            {
                throw new EmptyFieldException("Flight");
            }
           else if(capacity == 0)
            {
                throw new FullFlightException();
            }
           else if (string.IsNullOrWhiteSpace(fullName))
            {
                throw new EmptyFieldException("Name");
            }
            else if (string.IsNullOrWhiteSpace(citizenship))
            {
                throw new EmptyFieldException("Citizenship");
            }
            else
            {
                ReservationCode = reservationCode;
                FullName = fullName;
                Citizenship = citizenship;

                Status = status;

            } 
        }

        public override string ToString()
        {
            return ReservationCode + ", " +
                   FullName + ", " +
                   Citizenship + ", " +
                   Status + ", " +
                   FlightCode + ", " +
                   Airline + ", " +
                   OriginAirport + ", " +
                   DestAirport + ", " +
                   Day + ", " +
                   DepartureTime + ", " +
                   Capacity + ", " +
                   Price;
        }
    }
}
