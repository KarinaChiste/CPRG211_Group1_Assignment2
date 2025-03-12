using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRG211_Group1_Assignment2.Classes
{
    public class Flight
    {
        public string OriginAirport { get; set; } = string.Empty;
        public string DestAirport { get; set; } = string.Empty;
        public string Day { get; set; } = string.Empty;

        public Flight()
        {

        }

        public Flight (string originAirport, string destAirport, string day)
        {
            OriginAirport = originAirport;
            DestAirport = originAirport;
            Day = day;
        }
    }

}
