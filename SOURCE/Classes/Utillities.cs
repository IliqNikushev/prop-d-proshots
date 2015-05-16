using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public static class Utillities
    {
        public static T Get<T>(this MySql.Data.MySqlClient.MySqlDataReader reader, string name) where T : struct
        {
            if (Database.buildTesting)
                Database.AddBuildTestSearch(name);
            name = name.ToLower();
            for (int i = 0; i < reader.FieldCount; i++)
                if (reader.GetName(i).ToLower().EndsWith(name))
                {
                    if (Database.buildTesting)
                    {
                        Database.AddBuildTestFind(name);
                        try { reader.GetValue(0); }
                        catch { return default(T); }
                        if (reader.GetValue(i).GetType() != typeof(T))
                            Database.AddBuildTestTypeMissmatch(name, typeof(T), reader.GetValue(i).GetType());
                    }
                    return (T)reader.GetValue(i);
                }

            if (Database.buildTesting)
                return default(T);
            throw new KeyNotFoundException("Column not found, " + name + "\n" + string.Join(", ", reader.GetColumns()));
        }

        public static string GetStr(this MySql.Data.MySqlClient.MySqlDataReader reader, string name)
        {
            if (Database.buildTesting)
                Database.AddBuildTestSearch(name);
            name = name.ToLower();
            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (reader.GetName(i).ToLower().EndsWith(name))
                {
                    if (Database.buildTesting)
                    {
                        Database.AddBuildTestFind(name);
                        try { reader.GetValue(0); }
                        catch { return null; }
                        if (reader.GetValue(i).GetType() != typeof(string))
                            Database.AddBuildTestTypeMissmatch(name, typeof(string), reader.GetValue(i).GetType());
                    }

                    if (reader.GetValue(i).GetType() == typeof(System.DBNull))
                        return null;
                    else
                        return reader.GetString(i);
                }
            }

            if (Database.buildTesting)
                return null;
            throw new KeyNotFoundException("Column not found, " + name + "\n" + string.Join(", ", reader.GetColumns()));
        }

        public static T Apply<T>(this T t, Action<T> a)
        {
            a(t);
            return t;
        }

        public static int GetInt(this MySql.Data.MySqlClient.MySqlDataReader reader, string name)
        {
            return reader.Get<int>(name);
        }

        public static IEnumerable<string> GetColumns(this MySql.Data.MySqlClient.MySqlDataReader reader)
        {
            string[] result = new string[reader.FieldCount];
            for (int i = 0; i < result.Length; i++)
                result[i] = reader.GetName(i);
            return result;
        }

        public static string Capitalize(this string s)
        {
            return s.Substring(0, 1).ToUpper() + s.Substring(1);
        }

        public static string Lowerize(this string s)
        {
            return s.Substring(0, 1).ToLower() + s.Substring(1);
        }

        public static List<System.Reflection.PropertyInfo> GetAllProperties(this Type type)
        {
            List<System.Reflection.PropertyInfo> properties = new List<System.Reflection.PropertyInfo>();
            Type current = type;
            while (current != typeof(object))
            {
                properties.AddRange(current.GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public).Where(x => x.CanRead && x.CanWrite && !properties.Where(y=>x.Name == y.Name).Any()));
                current = current.BaseType;
            }
            return properties;
        }
    }
}
