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
            return;
            string query = "name = it's about's timet's' and free = ' to ' ' ' ' ' ";
            string expec = "name = it''s about''s tinet''s' and free = ' to '' '' '' '' '' ";
            var split = Utilities.SplitForQuery(query).Select(x => "|" + Utilities.ConvertForQuery(x)+"|");

            Console.WriteLine(Utilities.ConvertForQuery(query));
            Console.WriteLine(Utilities.ConvertForQuery(query) == expec);
            string spli = string.Join("", split);
            Console.WriteLine("IS:"+spli);
            Console.WriteLine("BE:"+expec);
            Console.WriteLine(spli == expec);
            return;
            /*
            string query = "name = 3 and p = 3 and u 2be is to be the one in 3,4,5 of 6 5 5 in 3 and a = 5";
            Console.WriteLine(query);
            Console.WriteLine(Utilities.ConvertToSQLValid(query));
            Console.WriteLine(Utilities.ConvertFromSQL(Utilities.ConvertToSQLValid(query)) == query);
            foreach (var item in Utilities.SplitForWHEREQuery(query))
            {
                Console.WriteLine("(" + item + ")");
            }
            Console.WriteLine(string.Join("",Utilities.SplitForWHEREQuery(query)) == query);
            return;*/
            Database.LogQuery += (sql) => Console.WriteLine("SQL>>\n" + sql+"\n");
            Visitor test = new Visitor("test", "id");
            test.Save();
            Visitor[] visitors = Visitor.All();
            Visitor v = Visitor.Find("name = 'test'");
            visitors = Visitor.Where("name = 'test' and id = 'tint'");
        }
    }
}