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
            // {typeof(Landmark), new Table("Landmarks", "id", "label", "description", "x", "y", "type", "logo")},
        {
            DateTime n = new DateTime(2015,6,29);
            
            EventLandmark ll = new EventLandmark("test", "a test landmark", 0, 0, n, n);

            ll.Create();

            return;


            RFID rfid = new RFID();
            rfid.OnDetect += rfid_OnDetect;
            Console.ReadKey();
            rfid.ToggleLED();
            return;
            Database.Insert<Landmark>("label, description, x,y ,type ", "PlayGround" , "Play ground for children", 100,100, "event");
            return;
            List<Visitor> myVisitors = Database.All<Visitor>();
            Visitor tester = Database.Find<Visitor>("users.userName = 'tester'");
            tester = Database.Find<Visitor>("{0}.username = {1}", Database.TableName<User>(), "tester");
            tester = Database.Find<Visitor>("|T|.RFID = {0}","4a00378203");

            return;    
            Database.ExecuteSQL("Create table test(Name varchar(15) NOT NULL) ENGINE=InnoDB DEFAULT CHARSET=latin1;");
            return;
            EventLandmark l = new EventLandmark("test", "a test landmark", 0, 0, DateTime.Today, DateTime.Now);
                   
            l.Create();
        }

        static void rfid_OnDetect(string obj)
        {
            Console.WriteLine(obj);
            Visitor v = Visitor.Authenticate(obj);
           // throw new NotImplementedException();
        }
    }
}
