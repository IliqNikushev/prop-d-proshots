using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public static class Utillities
    {
        public const string DateTimeFormat = "yyyy-MM-dd HH:mm:ss";

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
            if (prefix != "")
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
                if (prefixes[reader].Count > 0)
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

        private static object Get(this MySql.Data.MySqlClient.MySqlDataReader reader, string n, object defaultValue, Type wantedType)
        {
            bool found = false;
            string name = "";
            object result = defaultValue;
            if (distinctPrefixes.ContainsKey(reader))
                if (distinctPrefixes[reader].Where(x => x.Trim().Length > 0).Count() > 0)
                {
                    name = reader.DistinctPrefix() + reader.Prefix() + n.ToLower();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        found = reader.ProcessColumn(i, defaultValue, wantedType, name, out result);
                        if (found)
                        {
                            if (Database.buildTesting)
                            {
                                Database.AddBuildTestSearch(name);
                                Database.AddBuildTestFind(name);
                            }
                            return result;
                        }
                    }
                }

            name = reader.Prefix() + n.ToLower();

            if (Database.buildTesting)
                Database.AddBuildTestSearch(name);

            for (int i = 0; i < reader.FieldCount; i++)
            {
                found = reader.ProcessColumn(i, defaultValue, wantedType, name, out result);
                if (found) return result;
            }

            if (Database.buildTesting) return result; // to prevent exception, already covered by Testing class

            throw new KeyNotFoundException("Column not found, " + name + "\n" + string.Join(", ", reader.GetColumns()));
        }

        private static bool ProcessColumn(this MySql.Data.MySqlClient.MySqlDataReader reader, int i, object defaultValue, Type wantedType, string name, out object result)
        {
            if (reader.GetName(i).ToLower() == name)
            {
                if (Database.buildTesting)
                {
                    Database.AddBuildTestFind(name);
                    if (reader.GetFieldType(i) != wantedType)
                        Database.AddBuildTestTypeMissmatch(name, wantedType, reader.GetFieldType(i));

                    try { reader.GetValue(0); } // there are no rows
                    catch
                    {
                        result = defaultValue;
                        return true;
                    }
                }

                if (reader.GetValue(i).GetType() == typeof(System.DBNull))
                    result = defaultValue;
                else
                    result = reader.GetValue(i);
                return true;
            }
            result = defaultValue;
            return false;
        }

        public static T Get<T>(this MySql.Data.MySqlClient.MySqlDataReader reader, string name) where T : struct
        {
            //if (typeof(T) == typeof(DateTime))
            //    return (T)(object)DateTime.ParseExact(reader.GetStr(name), DateTimeFormat, System.Globalization.CultureInfo.CurrentCulture);
            object result = reader.Get(name, default(T), typeof(T));
            if (typeof(T) == typeof(bool))
                if (result.ToString() == "0")
                    result = false;
                else if (result.ToString() == "1")
                    result = true;
                else result = false;
            return (T)result;
        }

        public static string GetStr(this MySql.Data.MySqlClient.MySqlDataReader reader, string name)
        {
            return reader.Get(name, "", typeof(string)) as string;
        }

        public static string[] Columns(this MySql.Data.MySqlClient.MySqlDataReader reader)
        {
            string[] result = new string[reader.FieldCount];

            for (int i = 0; i < result.Length; i++)
                result[i] = reader.GetName(i);

            return result;
        }

        public static bool HasColumnAndNotNull(this MySql.Data.MySqlClient.MySqlDataReader reader, string name)
        {
            string n = reader.Prefix() + name.ToLower();
            string distinctN = reader.DistinctPrefix() + name.ToLower();
            if (distinctPrefixes.ContainsKey(reader))
                if (distinctPrefixes[reader].Where(x => x.Trim().Length > 0).Count() > 0)
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        string field = reader.GetName(i).ToLower();
                        if (field == distinctN)
                        {
                            if (Database.buildTesting) return true;

                            if (reader.GetValue(i).GetType() != typeof(System.DBNull))
                                return true;
                            return false;
                        }
                    }
                }

            for (int i = 0; i < reader.FieldCount; i++)
            {
                string field = reader.GetName(i).ToLower();
                if (field == n)
                {
                    if (Database.buildTesting) return true;

                    if (reader.GetValue(i).GetType() != typeof(System.DBNull))
                        return true;
                    return false;
                }
            }
            return false;
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
                properties.AddRange(current.GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public).Where(x => x.CanRead && x.CanWrite && !properties.Where(y => x.Name == y.Name).Any()));
                current = current.BaseType;
            }
            return properties;
        }

        /// <summary>
        /// uses string.Format on the specified string instance with the args given, by making them secure for database use ( replaces ' )
        /// </summary>
        public static string Args(this string s, params object[] args)
        {
            return string.Format(s, args.Select(x=>x == null? "NULL" : x.ToString().Replace("'","''")).ToArray());
        }

        /// <summary>
        /// uses string.Format on the specified string instance with the arguments given, by making the arguments ready for the database
        /// </summary>
        public static string Arg(this string pattern, params object[] arguments)
        {
            return string.Format(pattern, arguments.Format());
        }

        public static object[] Format(this IEnumerable<object> parameters)
        {
            return parameters.Select(x =>
            {
                if (x is string) return "'" + x.ToString().Replace("'", "''") + "'";
                if (x is DateTime) return "'" + ((DateTime)x).ToString(DateTimeFormat) + "'";
                if (x == null) return "NULL";
                if (x is Database.Table) return (x as Database.Table).Name;
                if (x is bool) return ((bool)x ? 1 : 0).ToString();
                if (x.GetType().IsClass) return "'" + x.ToString().Replace("'", "''") + "'";
                return x.ToString();
            }).ToArray();
        }
    }
}
