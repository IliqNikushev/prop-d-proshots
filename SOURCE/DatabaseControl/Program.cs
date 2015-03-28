using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseControl
{
    class Program
    {
        static void Main(string[] args)
        {
            string testS = "name = test and name = 'it's in in in' and int in 'in in in the tint's'".ToUpper();
            string resultS = Utilities.ConvertToQuery(testS);
            Console.WriteLine("----");
            Console.WriteLine(resultS);
            
            Database.LogQuery += (sql) => Console.WriteLine("SQL>>\n" + sql+"\n");
            Visitor test = new Visitor("test", "id");
            test.Save();
            Visitor[] visitors = Visitor.All();
            Visitor v = Visitor.Find("name = 'test'");
            visitors = Visitor.Where("name = 'test' and id = 'tint'").Select("name");
        }
    }
}