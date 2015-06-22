using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_PayPal
{
    static class Install
    {
#warning set the machine based on the install prefferences ( Build for every machine a new version )
        public static Classes.PayPalMachine Machine = Classes.Database.All<Classes.PayPalMachine>().First();
    }
}
