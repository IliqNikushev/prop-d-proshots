using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;
using System.Threading;

namespace ConsoleTester
{
    class Program
    {
        public delegate void numberLogger(int n);
        public static event numberLogger elog1;
        public static event numberLogger elog2;
        public static event numberLogger elog3;
        public static void LogNumber(int log)
        {
            Console.WriteLine(log);
        }
        //public static void Mass(int id, int length)
        //{
        //    Console.WriteLine(id + " " + length);
        //}
        //public static void NoParam(int[] intz)
        //{
        //    Console.WriteLine(String.Join(", ",intz));
        //}
        //public static void Param(params int[] param)
        //{
        //    Console.WriteLine(String.Join(", ", param));
        //}
        static void Main(string[] args)
        {
            RFID rf= new RFID();
            rf.OnDetect += x => { };
            return;
            numberLogger log1 = x => { };
            numberLogger log2 = new numberLogger(LogNumber);
            numberLogger log3 = LogNumber;
            elog1 = x => { };
            elog2 = new numberLogger(LogNumber);
            elog3 = LogNumber;
            for (int i = 0; i < 5; i++)
			{
                int ai = i;
			    log1+= x => Console.WriteLine(ai);

			}
            log1(3);
            return;
            int a = 3;
            new System.Threading.Thread(() => {while(true){ Thread.Sleep(500); a += 1;} }).Start();
            while(true)
            { System.Threading.Thread.Sleep(1000); Console.WriteLine(a); }
            return;
            RentableItem item = Database.All<RentableItem>().Last();
            Visitor visitor = Database.Find<Visitor>("users.username = {0}","tester");
            new RentableItemHistory(item, visitor);
            return;
            //int[] ints = new int[]{1,2,3,4};
            //Param(1,2,3);
            //NoParam(ints);
            //Mass(1,2);
            //return;
            Database.ExecuteSQL("Create table test(Name varchar(15) NOT NULL) ENGINE=InnoDB DEFAULT CHARSET=latin1;");
            return;
            EventLandmark l = new EventLandmark("test", "a test landmark", 0, 0, DateTime.Today, DateTime.Now);
            l.Create();
        }
    }
}
