using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRG211_Group1_Assignment2.Classes
{
    // FlightSearch class
    public class FlightSearch
    {
        // access flights.csv file
        private static string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
            @"..\..\..\..\Data\flights.csv");
        public static List<Flight> flights = new List<Flight>();

        // class calls PopulateFlights method
        public FlightSearch()
        {
            PopulateFlights();
        }

        // GetFlights method to return flights from Flight list 
        public static List<Flight> GetFlights()
        {
            return flights;
        }

        // PopulateFlights method to parse flights from flights.csv into Flight list
        public void PopulateFlights()
        {
            flights.Clear();
            FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string line;
            string[] details;
            Flight flight;
            while (!sr.EndOfStream)
            {
                line = sr.ReadLine()!;
                details = line.Split(',');
                flight = new Flight(details[0], details[1], details[2], details[3], details[4], details[5], int.Parse(details[6]), details[7]);
                flights.Add(flight);
            }
            sr.Close();
        }

    }
}
