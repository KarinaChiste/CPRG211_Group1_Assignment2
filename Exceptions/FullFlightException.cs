using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRG211_Group1_Assignment2.Exceptions
{
    public class FullFlightException : Exception
    {
        public FullFlightException(): base("Full Flight, can't book ticket") { }
    }
}
