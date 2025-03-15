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
        public static List<Reservation> reservations = new List<Reservation>();

        //List<Reservation> reservations;
        //List<Reservation> reservations2 = GetReservations();

        public Reservation makeReservation(Flight flight, string name, string citizenship)
        {
            List<Reservation> allReservations = GetReservations();
            Reservation reservation = new Reservation(flight.FlightCode, flight.Airline, flight.OriginAirport, flight.DestAirport, flight.Day, flight.DepartureTime, flight.Capacity, flight.Price, GenerateReservationCode(), name, citizenship, true);
            flight.Capacity--;
            //allReservations = GetReservations();
            allReservations.Add(reservation);
            JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
            
                string jsonString = JsonSerializer.Serialize(allReservations, options);
                File.WriteAllText(@"..\..\..\..\Data\reservations.json", jsonString);
            
            
            return reservation;

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

        public  List<Reservation> GetReservations()
        {
            var jsonData = File.ReadAllText(@"..\..\..\..\Data\reservations.json");
            JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true, IncludeFields =true, PropertyNameCaseInsensitive = true };
            
                List<Reservation> reservations = JsonSerializer.Deserialize<List<Reservation>>(jsonData, options);
                return reservations;
            
            
        }

    }

}


