using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CPRG211_Group1_Assignment2.Exceptions;

/*Names: Karina, Ashton, Jasprit, Caden
 * Date: March 14 2025 
 * Assignment: CPRG211 Assignment 2
 */

//Find Reservations and Display Them, save to file
namespace CPRG211_Group1_Assignment2.Classes
{
    public class ReservationManager
    {
        public static List<Reservation> reservations = new List<Reservation>();
        //List<Reservation> reservations;

        public ReservationManager()
        {
            PopulateReservations();
        }

        public void PopulateReservations()
        {
            try
            {
                var jsonData = File.ReadAllText(@"..\..\..\..\Data\reservations.json");
                reservations = JsonSerializer.Deserialize<List<Reservation>>(jsonData);
            }
            catch (Exception)
            {
                reservations = new List<Reservation>();
            }
        }

        public Reservation makeReservation(Flight flight, string name, string citizenship)
        {
            if(reservations.Count == 0)
            {
                PopulateReservations();
            }
            Reservation reservation = new Reservation(flight.FlightCode, flight.Airline, flight.OriginAirport, flight.DestAirport, flight.Day, flight.DepartureTime, flight.Capacity, flight.Price, GenerateReservationCode(), name, citizenship);
            flight.Capacity--;
            reservations.Add(reservation);
            persist();
            return reservation;

        }

        public void persist()
        {
            
            JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(reservations, options);
            
            File.WriteAllText(@"..\..\..\..\Data\reservations.json", jsonString);

        }

        public string GenerateReservationCode()
        {
            while (true)
            {
                string valid = "Y";
                Random random = new Random();
                string randomNumber = random.Next(0, 9999).ToString("D4");
                string potentialCode = "F" + randomNumber;
                StreamReader reader = new StreamReader(@"..\..\..\..\Data\ReservationCodes.txt");
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
                    StreamWriter writer = File.AppendText(@"..\..\..\..\Data\ReservationCodes.txt");
                    writer.WriteLine(potentialCode);
                    writer.Close();
                    return potentialCode;

                }
            }
        }

    }

}


