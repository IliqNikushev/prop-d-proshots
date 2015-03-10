using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Exceptions
{
    public class InvalidPayPalLogFileException : Exception
    {
        public InvalidPayPalLogFileException() : base("Not a valid paypal log file") { }
    }
}
