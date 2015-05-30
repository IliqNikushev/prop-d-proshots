using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;

namespace ConsoleTester
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.ExecuteSQL("Create table test(Name varchar(15) NOT NULL) ENGINE=InnoDB DEFAULT CHARSET=latin1;");
            return;
            EventLandmark l = new EventLandmark("test", "a test landmark", 0, 0, DateTime.Today, DateTime.Now);
            l.Create();
        }
    }
}
