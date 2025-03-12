using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPRG211_Group1_Assignment2.Exceptions;

namespace CPRG211_Group1_Assignment2.Classes
{
    public class Reservation:Flight
    {
        
       public string ReservationCode { get; set; }
       
       public string FullName { get; set; }
        public string Citizenship { get; set; }

        public Reservation(Flight flight,string reservationCode, string name, string citizenship)
        {
           if (flight == null)
            {
                throw new EmptyFieldException();
            }
           else if (string.IsNullOrWhiteSpace(name))
            {
                throw new EmptyFieldException();
            }
            else if (string.IsNullOrWhiteSpace(citizenship))
            {
                throw new EmptyFieldException();
            }
            else
            {
                ReservationCode = reservationCode;
                FullName = name;
                Citizenship = citizenship;
            }
            
        } 
        

    
    }
}
