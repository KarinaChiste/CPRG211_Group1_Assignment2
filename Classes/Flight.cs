using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRG211_Group1_Assignment2.Classes
{
    public class Flight
    {
        public string ReservationCode { get; set; }
        public string Airline { get; set; }
        public string OriginAirport { get; set; } = string.Empty;
        public string DestAirport { get; set; } = string.Empty;
        public string Day { get; set; } = string.Empty;
        public string DepartureTime { get; set; }
        public string Capacity { get; set; }
        public string Price { get; set; }

        //public Flight()
        //{

        //}

        public Flight (string reservationCode, string airline, string originAirport, string destAirport, 
            string day, string departureTime, string capacity, string price)
        {
            ReservationCode = reservationCode;
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
            return ReservationCode + ", " +
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
