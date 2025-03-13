using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRG211_Group1_Assignment2.Classes
{
    public class FlightSearch
    {
        private static string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
            @"..\..\..\..\Data\flights.csv");
        public static List<Flight> flights = new List<Flight>();

        public FlightSearch()
        {
            PopulateFlights();
        }

        public static List<Flight> GetFlights()
        {
            return flights;
        }

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
                flight = new Flight(details[0], details[1], details[2], details[3], details[4], details[5], details[6], details[7]);
                flights.Add(flight);
            }
            sr.Close();
        }

    }
}
