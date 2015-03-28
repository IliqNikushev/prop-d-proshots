using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseControl
{
    public class Database
    {

#warning IMPLEMENT REAL DATABASE
        /// <summary>
        /// Temp Database
        /// </summary>
        public static Dictionary<Type, Dictionary<string, object[]>> records = new Dictionary<Type, Dictionary<string, object[]>>(){
        {typeof(Visitor), new  Dictionary<string,object[]>(){
            {"Name", new string[]{"test"}},
            {"ID", new string[]{"id"}}
        }
        }
        };

        public static Action<string> LogQuery = (x) => { };

        public static readonly Dictionary<Type, string> Tables = new Dictionary<Type, string>(){
            {typeof(Visitor), "Visitors"}
        };

        [Serializable]
        public class TableNotFoundException : Exception
        {
            public TableNotFoundException() { }
            public TableNotFoundException(Type type) : base("FOR : " + type.Name) { }
        }
    }
}