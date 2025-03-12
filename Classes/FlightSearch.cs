using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRG211_Group1_Assignment2.Classes
{
    public class FlightSearch
    {
        private string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
            @"..\..\..\data\flights.csv");
        private static List<Flight> flights = new List<Flight>();

        public FlightSearch()
        {
            PopulateFlights();
        }

        public static List<Flight> GetFlights()
        {
            return flights;
        }

        private void PopulateFlights()
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
                flight = new Flight(details[2], details[3], details[4]);
            }
            sr.Close();
        }

    }
}

//const string PATH = @"..\..\..\data\flights.csv";
//const string SEP = ",";

//static List<Flight> ReadFile()
//{
//    List<Flight> flights = new List<Flight>();
//    string line;
//    string[] details;
//    Flight originAirport;
//    string destAirport;
//    string day;

//    StreamReader read = new StreamReader(PATH);

//    while (!read.EndOfStream)
//    {
//        line = read.ReadLine();
//        details = line.Split(SEP);
//        originAirport = details[2];
//        destAirport = details[3];
//        day = details[4];
//    }
//    read.Close();
//    return flights;
//}

//List<Flight> flights = ReadFile();

//private List<Flight> FindFlight(string originAirport, string destAirport, string day)
//{
//    return flights.Where(r =>
//        (string.IsNullOrWhiteSpace(originAirport) || r.OriginAirport.Equals(originAirport, StringComparison.OrdinalIgnoreCase)) &&
//        (string.IsNullOrWhiteSpace(destAirport) || r.DestAirport.Equals(destAirport, StringComparison.OrdinalIgnoreCase)) &&
//        (string.IsNullOrWhiteSpace(day) || r.Day.Equals(day, StringComparison.OrdinalIgnoreCase))
//        ).ToList();

//    if (string.IsNullOrWhiteSpace(originAirport) && string.IsNullOrWhiteSpace(destAirport) && string.IsNullOrWhiteSpace(day))
//    {
//        return flights;
//    }
//}
