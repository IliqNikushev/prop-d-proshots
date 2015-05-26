using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public static class Utillities
    {
        private static Dictionary<MySql.Data.MySqlClient.MySqlDataReader, Stack<string>> prefixes = new Dictionary<MySql.Data.MySqlClient.MySqlDataReader, Stack<string>>();
        private static Dictionary<MySql.Data.MySqlClient.MySqlDataReader, Stack<string>> distinctPrefixes = new Dictionary<MySql.Data.MySqlClient.MySqlDataReader, Stack<string>>();

        public static void ClearPrefixes(this MySql.Data.MySqlClient.MySqlDataReader reader)
        {
            if (prefixes.ContainsKey(reader))
                prefixes.Remove(reader);
            if (distinctPrefixes.ContainsKey(reader))
                distinctPrefixes.Remove(reader);
        }

        public static void AddDistinctPrefix(this MySql.Data.MySqlClient.MySqlDataReader reader, string prefix)
        {
            if (!distinctPrefixes.ContainsKey(reader))
                distinctPrefixes.Add(reader, new Stack<string>());
            if(prefix != "")
                if (prefix.Last() != '_') prefix += "_";
            distinctPrefixes[reader].Push(prefix.ToLower());
        }

         public static void RemoveDistinctPrefix(this MySql.Data.MySqlClient.MySqlDataReader reader)
         {
             if (distinctPrefixes.ContainsKey(reader))
                 if (distinctPrefixes[reader].Count > 0)
                     distinctPrefixes[reader].Pop();
         }

        public static void AddPrefix(this MySql.Data.MySqlClient.MySqlDataReader reader, string prefix)
        {
            if (!prefixes.ContainsKey(reader))
                prefixes.Add(reader, new Stack<string>());
            if (prefix != "")
                if (prefix.Last() != '_') prefix += "_";
            prefixes[reader].Push(prefix.ToLower());
        }

        public static void RemovePrefix(this MySql.Data.MySqlClient.MySqlDataReader reader)
        {
            if (prefixes.ContainsKey(reader))
                if(prefixes[reader].Count > 0)
                    prefixes[reader].Pop();
        }

        private static string Prefix(this MySql.Data.MySqlClient.MySqlDataReader reader)
        {
            if (prefixes.ContainsKey(reader))
                return string.Join("", prefixes[reader].Reverse());
            return "";
        }

        private static string DistinctPrefix(this MySql.Data.MySqlClient.MySqlDataReader reader)
        {
            if (distinctPrefixes.ContainsKey(reader))
                return string.Join("", distinctPrefixes[reader].Reverse());
            return "";
        }

        private static object Get(this MySql.Data.MySqlClient.MySqlDataReader reader, string n, object defaultValue)
        {
            string name = "";

            if(distinctPrefixes.ContainsKey(reader))
                if (distinctPrefixes[reader].Where(x=>x.Trim().Length>0).Count() > 0)
                {
                    name = reader.DistinctPrefix() + reader.Prefix() + n.ToLower();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        if (reader.GetName(i).ToLower() == name)
                        {
                            if (Database.buildTesting)
                                Database.AddBuildTestSearch(name);

                            if (Database.buildTesting)
                            {
                                Database.AddBuildTestFind(name);
                                try { reader.GetValue(0); }
                                catch { return defaultValue; }
                                if (reader.GetValue(i).GetType() != defaultValue.GetType())
                                    Database.AddBuildTestTypeMissmatch(name, typeof(string), reader.GetValue(i).GetType());
                            }

                            if (reader.GetValue(i).GetType() == typeof(System.DBNull))
                                return defaultValue;
                            else
                                return reader.GetValue(i);
                        }
                    }
                }

            name = reader.Prefix() + n.ToLower();

            if (Database.buildTesting)
                Database.AddBuildTestSearch(name);

            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (reader.GetName(i).ToLower() == name)
                {
                    if (Database.buildTesting)
                    {
                        Database.AddBuildTestFind(name);
                        try { reader.GetValue(0); }
                        catch { return defaultValue; }
                        if (reader.GetValue(i).GetType() != defaultValue.GetType())
                            Database.AddBuildTestTypeMissmatch(name, typeof(string), reader.GetValue(i).GetType());
                    }

                    if (reader.GetValue(i).GetType() == typeof(System.DBNull))
                        return defaultValue;
                    else
                        return reader.GetValue(i);
                }
            }


            if (Database.buildTesting)
                return defaultValue;
            throw new KeyNotFoundException("Column not found, " + name + "\n" + string.Join(", ", reader.GetColumns()));
        }

        public static T Get<T>(this MySql.Data.MySqlClient.MySqlDataReader reader, string name) where T : struct
        {
            return (T)reader.Get(name, default(T));
        }

        public static string GetStr(this MySql.Data.MySqlClient.MySqlDataReader reader, string name)
        {
            return reader.Get(name, "") as string;
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

        public static string Arg(this string pattern, params object[] arguments)
        {
            return string.Format(pattern, arguments.Format());
        }

        public static IEnumerable<object> Format(this IEnumerable<object> parameters)
        {
            return parameters.Select(x =>
            {
                if (x is string) return "'" + x.ToString().Replace("'", "''") + "'";
                if (x is DateTime) return "'" + ((DateTime)x).ToString("yyyy-MM-dd HH:mm:ss") + "'";
                if (x == null) return "NULL";
                return x;
            });
        }
    }
}
