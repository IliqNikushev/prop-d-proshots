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
        private static void f()
        {
            ShopWorkplace shop = Database.Find<ShopWorkplace>("");
            Employee e = new Employee(0, "Shop", "Employee", "Shop", "Pass", "Email", shop, "cashier");
            User u = Database.Insert<User>("firstName, lastName, userName, password, email, type", e.FirstName, e.LastName, e.Username, e.Password, e.Email, "employee");
            Database.Insert(e, "user_id, workplace_id, job", u.ID, e.Workplace.ID, e.Duty);

            e = new Employee(0, "ShopManager", "EmployeeManager", "ShopManager", "Pass", "Email", shop, "shopmanager");
            u = Database.Insert<User>("firstName, lastName, userName, password, email, type", e.FirstName, e.LastName, e.Username, e.Password, e.Email, "employee");
            Database.Insert(e, "user_id, workplace_id, job", u.ID, e.Workplace.ID, e.Duty);
        }
        static void Main(string[] args)
            // {typeof(Landmark), new Table("Landmarks", "id", "label", "description", "x", "y", "type", "logo")},
        {
            Database.OnUnableToProcessSQL += (x, y) => { Console.WriteLine(x.Message); Console.WriteLine(y); };
            f();
            return;
            var q = Database.Find<Visitor>("user_id=1").RentedItems;
            Console.WriteLine(q.Count);
            return;
            Visitor v = Visitor.Authenticate("tester", "test") as Visitor;
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
