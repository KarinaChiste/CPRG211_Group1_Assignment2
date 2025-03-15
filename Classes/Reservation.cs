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
        public string FullName { get; set; }
        public string Citizenship { get; set; }

        public bool Status {  get { return status; } set { status = value; } }
        public Reservation(string flightCode, string airline, string originAirport, string destAirport,
            string day, string departureTime, int capacity, string price, string reservationCode, string name, string citizenship) : 
            base( flightCode,  airline, originAirport, destAirport, day,  departureTime, capacity, price)
        {
           if (flightCode == null)
            {
                throw new EmptyFieldException("Flight");
            }
           else if(capacity == 0)
            {
                throw new FullFlightException();
            }
           else if (string.IsNullOrWhiteSpace(name))
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
                FullName = name;
                Citizenship = citizenship;
                Status = true;
            } 
        }
    }
}
