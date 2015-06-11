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
        static void Georgi()
        {
            RFID rf = new RFID();
            rf.OnDetect += rf_OnDetect;
            Console.ReadKey();
            rf.ToggleLED();
        }

        static void rf_OnDetect(string tag)
        {
            Visitor v = Visitor.Authenticate(tag);
            Console.WriteLine(v== null);
            if(v)
                Console.WriteLine(v.FullName);
            Console.WriteLine(tag);
        }
        static void Main(string[] args)
            // {typeof(Landmark), new Table("Landmarks", "id", "label", "description", "x", "y", "type", "logo")},
        {
            Tent arg = Classes.Database.Find<Tent>("|T|.location = 1");
            Console.WriteLine(arg.BookedFor);
            return;
            Georgi();
            return;
            Console.WriteLine("{0} = {1}",1,DateTime.Now);
            Console.WriteLine(String.Format("{0} = {1}", 1, DateTime.Now));
            Console.WriteLine("{0} = {1}".Arg(1, DateTime.Now));
            return;
            AppointedItem api = new AppointedItem("s", "x");
            api = api.Create() as AppointedItem;
            Appointment ap = new Appointment(api, Visitor.Authenticate("tester", "test") as Visitor, "desc");
            ap.Create();
            return;
            Classes.AppointedItem item = new Classes.AppointedItem("lenovo","x");
            //Database.ExecuteSQL("Insert into Items (brand, model,type, description,icon)");
            int id=0;
            Database.ExecuteSQL("INSERT INTO `dbi317294`.`items` (`ID`, `Brand`, `Model`, `Type`, `Description`, `dateCreated`, `dateModified`, `icon`) VALUES (NULL, 'Lenovo', '152', 'appointed', 'Its a laptop', '0000-00-00 00:00:00', '0000-00-00 00:00:00', 'item404.jpg');");
            Database.ExecuteSQLWithResult("SELECT ID FROM `items` WHERE Brand = 'Lenovo' AND Model = '1337' ORDER BY ID DESC limit 1;", x => { x.Read(); id = x.GetInt("ID"); });
            Console.WriteLine(id);
            item = new AppointedItem(10, null, null, null, null, null, null);
            Appointment app = new Appointment(item, Visitor.Authenticate("tester", "test") as Visitor, "desc");
            app.Create();
            return;
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
