using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public static class Utillities
    {
        public static T Get<T>(this MySql.Data.MySqlClient.MySqlDataReader reader, string name)
        {
            name = name.ToLower();
            for (int i = 0; i < reader.FieldCount; i++)
			    if(reader.GetName(i).ToLower().EndsWith(name)) return (T)reader.GetValue(i);
			
            throw new KeyNotFoundException("Column not found, "+ name);
        }

        public static string GetStr(this MySql.Data.MySqlClient.MySqlDataReader reader, string name)
        {
            return reader.Get<string>(name);
        }

        public static int GetInt(this MySql.Data.MySqlClient.MySqlDataReader reader, string name)
        {
            return reader.Get<int>(name);
        }
    }
}
