using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;

namespace Angel_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Classes.RFID rfid = new Classes.RFID();
            rfid.OnDetect += rfid_OnDetect;
            Console.ReadKey();
            rfid.ToggleLED();
            
        }

        static void rfid_OnDetect(string obj)
        {
            Visitor v = Database.Find<Visitor>("id = 1");
            v = Database.Find<Visitor>("id = {0}", 1);
            Console.WriteLine(obj);
            
            InformationKioskWorkplace d = new InformationKioskWorkplace(0, 0, 0);
            try
            {
                d.GiveIDCardToVisitor(v, obj);
            }
            catch(Exception ex) { Console.WriteLine("error," + ex.Message); }
        }
    }
}
