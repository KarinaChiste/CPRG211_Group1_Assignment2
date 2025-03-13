using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRG211_Group1_Assignment2.Classes
{
    public class Flight
    {
        private int capacity;
        public string FlightCode { get; set; }
        public string Airline { get; set; }
        public string OriginAirport { get; set; } = string.Empty;
        public string DestAirport { get; set; } = string.Empty;
        public string Day { get; set; } = string.Empty;
        public string DepartureTime { get; set; }
        public int Capacity { get { return capacity; } set { capacity = value; } }
        public string Price { get; set; }

        //public Flight()
        //{

        //}

        public Flight (string flightCode, string airline, string originAirport, string destAirport, 
            string day, string departureTime, int capacity, string price)
        {
            FlightCode = flightCode;
            Airline = airline;
            OriginAirport = originAirport;
            DestAirport = destAirport;
            Day = day;
            DepartureTime = departureTime;
            Capacity = capacity;
            Price = price;
        }

        public override string ToString()
        {
            return FlightCode + ", " +
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
