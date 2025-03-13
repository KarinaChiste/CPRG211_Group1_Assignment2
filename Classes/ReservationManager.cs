using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CPRG211_Group1_Assignment2.Exceptions;

namespace CPRG211_Group1_Assignment2.Classes
{
    public class ReservationManager
    {
        public List<Reservation> FindReservation(string? reservationCode, string? airline, string? name)
        {
            List<Reservation> reservations = new List<Reservation>();

            if (File.Exists("reservations.json"))
            {
                string jsonData = File.ReadAllText("reservations.json");

                if (!string.IsNullOrEmpty(jsonData))
                {
                    reservations = JsonSerializer.Deserialize<List<Reservation>>(jsonData);

                    if (reservations == null)
                    {
                        reservations = new List<Reservation>();
                    }
                }
            }

            var filteredReservations = reservations.Where(r =>
                (string.IsNullOrEmpty(reservationCode) || r.ReservationCode.Contains(reservationCode, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrEmpty(airline) || r.Airline.Contains(airline, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrEmpty(name) || r.FullName.Contains(name, StringComparison.OrdinalIgnoreCase)) // Changed Name to FullName
             ).ToList();

            return filteredReservations;
        }


        public Reservation makeReservation(Flight flight, string name, string citizenship)
        {
            if (flight.Capacity == 0)
            {
                throw new FullFlightException();
            }
            else
            {
                Reservation reservation = new Reservation(flight.FlightCode, flight.Airline, flight.OriginAirport, flight.DestAirport, flight.Day, flight.DepartureTime,flight.Capacity, flight.Price, GenerateReservationCode(), name, citizenship);
                flight.Capacity--;
                JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString = JsonSerializer.Serialize(reservation, options);
                File.AppendAllText("reservations.json", jsonString);
                return reservation;
            }
        }
        public string GenerateReservationCode()
        {
            while (true)
            {
                string valid = "Y";
                Random random = new Random();
                string randomNumber = random.Next(0, 9999).ToString("D4");
                string potentialCode = "F" + randomNumber;
                StreamReader reader = new StreamReader(@"..\..\..\Data\ReservationCodes.txt");
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (potentialCode.Equals(line))
                    {
                        valid = "N";
                        break;
                    }
                }
                reader.Close();
                if (valid == "Y")
                {
                    StreamWriter writer = File.AppendText(@"..\..\..\Data\ReservationCodes.txt");
                    writer.WriteLine(potentialCode);
                    writer.Close();
                    return potentialCode;
                   
                }
            }
            

        }

    }
    
}
