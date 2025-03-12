﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRG211_Group1_Assignment2.Classes
{
    public class ReservationManager
    {


        //public Reservation makeReservation(Flight flight, string name, string citizenship)
        //{
        //    if(flightCapacity == 0)
        //    {
        //        throw new FullFlightException();
        //    }
            
        //}
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
