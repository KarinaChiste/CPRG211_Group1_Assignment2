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
        //private bool status;
        public string ReservationCode { get; set; }
        public string FullName { get; set; }
        public string Citizenship { get; set; }

        public bool Status { get; set; }
       public Reservation() { }
        public Reservation(string flightCode, string airline, string originAirport, string destAirport,
            string day, string departureTime, int capacity, string price, string reservationCode, string name, string citizenship, bool status) : 
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
                this.ReservationCode = reservationCode;
                this.FullName = name;
               this.Citizenship = citizenship;
                this.Status = status;
               this.FlightCode = flightCode;
                this.Airline = airline;
                this.OriginAirport = originAirport;
                this.DestAirport = destAirport;
                this.Day = day;
                this.DepartureTime = departureTime;
                this.Capacity = capacity;
                this.Price = price;

            } 
        }
    }
}
