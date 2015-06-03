using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public partial class Database
    {
        public static List<string> consistencyExceptions;

        static Database() { System.IO.StreamWriter sw = new System.IO.StreamWriter("sql.txt"); using (sw) { } }
        public static void CheckConsistency()
        {
            try
            {
                consistencyExceptions = new List<string>();

                foreach (var table in tables)
                {
                    try
                    {
                        ExecuteSQL("Select " + table.Value.ToString(), true);
                    }
                    catch (Exception ex)
                    {
                        consistencyExceptions.Add(ex.GetType().Name.Replace("Exception", ":") + ex.Message + "\r\n" + table.Value.ToString());
                    }
                }
                foreach (var type in Assembly.GetTypes().Where(x => x.IsSubclassOf(typeof(Record))))
                {
                    if (!recordBuildDefinitions.ContainsKey(type))
                    {
                        List<System.Reflection.PropertyInfo> properties = type.GetAllProperties();
                        IEnumerable<string> fields = properties.Select(x =>
                        {
                            string t = x.PropertyType.ToString().
                            Replace("System.Int32", "int").
                            Replace("System.Double", "double").
                            Replace("System.Boolean", "bool").
                            Replace("System.Bool", "bool").
                            Replace("System.Object", "object").
                            Replace("System.Char", "char").
                            Replace("System.Decimal", "decimal").
                            Replace("System.String", "string");

                            return t + " " + x.Name.Lowerize() + " = " + "reader.Get<" + t + ">(\"" + x.Name + "\");";
                        });

                        consistencyExceptions.Add("Don't know how to build " + type.Name);
                        consistencyExceptions.Add(string.Join("\r\n", fields));
                        consistencyExceptions.Add("return new " + type + "(" + string.Join(", ", properties.Select(x => x.Name.Lowerize())) + ");");
                        consistencyExceptions.Add("");
                    }
                }

                consistencyExceptions.Add("");

                foreach (var type in Assembly.GetTypes().Where(x => x.IsSubclassOf(typeof(Record))))
                {
                    if (tables.ContainsKey(type))
                    {
                        List<System.Reflection.PropertyInfo> properties = type.GetAllProperties();

                        HashSet<string> found = null;
                        try
                        {
                            ExecuteSQLWithResult("Select " + tables[type], (x) => found = new HashSet<string>(x.GetColumns().Select(y => y.ToLower())), true);
                        }
                        catch (Exception ex)
                        {
                            consistencyExceptions.Add(ex.GetType().Name.Replace("Exception", ":") + ex.Message + "\r\n" + tables[type]);
                            continue;
                        }
                        HashSet<string> current = new HashSet<string>(properties.Select(x =>
                        {
                            string name = x.Name;
                            object[] columnDefinition = x.GetCustomAttributes(typeof(ColumnAttribute), true);
                            if (columnDefinition.Length != 0)
                                name = (columnDefinition[0] as ColumnAttribute).Name;
                            return name.ToLower();
                        }));

                        foreach (string column in found)
                            if (!current.Contains(column))
                                consistencyExceptions.Add(type.Name + "." + column + " Not found locally");
                        consistencyExceptions.Add("");

                        foreach (string column in current)
                            if (!found.Contains(column))
                                consistencyExceptions.Add(type.Name + "." + column + " Not found server side");

                        consistencyExceptions.Add("");
                        System.Reflection.ConstructorInfo[] constructors = type.GetConstructors();
                        Dictionary<Type, int> constructorRequiredTypes = new Dictionary<Type, int>();
                        foreach (var property in properties)
                        {
                            if (!constructorRequiredTypes.ContainsKey(property.PropertyType))
                                constructorRequiredTypes.Add(property.PropertyType, 0);
                            constructorRequiredTypes[property.PropertyType] += 1;
                        }

                        Dictionary<Type, int> constructorRequiredTypesCopy = new Dictionary<Type, int>(constructorRequiredTypes);
                        bool isFound = true;
                        foreach (var constructor in type.GetConstructors())
                        {
                            foreach (var parameter in constructor.GetParameters())
                            {
                                if (!constructorRequiredTypes.ContainsKey(parameter.ParameterType))
                                {
                                    isFound = false;
                                    break;
                                }
                                constructorRequiredTypes[parameter.ParameterType] -= 1;
                                if (constructorRequiredTypes[parameter.ParameterType] < 0)
                                {
                                    isFound = false;
                                    break;
                                }
                            }
                            foreach (var item in constructorRequiredTypes)
                            {
                                if (item.Value > 0)
                                {
                                    isFound = false;
                                    break;
                                }
                            }
                            if (!isFound)
                            {
                                IEnumerable<KeyValuePair<string, string>> fields = properties.Select(x => new KeyValuePair<string, string>(
                                    x.PropertyType.ToString().
                                        Replace("System.Int32", "int").
                                        Replace("System.Double", "double").
                                        Replace("System.Boolean", "bool").
                                        Replace("System.Bool", "bool").
                                        Replace("System.Object", "object").
                                        Replace("System.Char", "char").
                                        Replace("System.Decimal", "decimal").
                                        Replace("System.String", "string"), x.Name));

                                string constructorStr = string.Join(", ", fields.Select(x => x.Key + " " + x.Value.Lowerize()));
                                string initialize = string.Join("\r\n", properties.Select(x => "this." + x.Name + " = " + x.Name.Lowerize() + ";"));

                                consistencyExceptions.Add("Default Constructor not found for " + type.Name);
                                consistencyExceptions.Add(string.Join("\r\n", constructorRequiredTypes.Select(x => x.Key + " => " + x.Value)));
                                consistencyExceptions.Add("public " + type.Name + "(" + constructorStr + ")\r\n{\r\n" + initialize + "\r\n}");
                                break;
                            }
                            constructorRequiredTypes = new Dictionary<Type, int>(constructorRequiredTypesCopy);
                        }
                    }
                    else
                        consistencyExceptions.Add("Table not found for " + type.Name);
                }

                using (System.IO.StreamWriter sw = new System.IO.StreamWriter("consistency.txt"))
                {
                    foreach (var item in consistencyExceptions)
                        sw.WriteLine(item);
                }
            }
            catch (Exception ex)
            {
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter("Initializer.txt"))
                {
                    sw.WriteLine(ex.GetType().Name);
                    sw.WriteLine(ex.Message);
                }
            }
        }

        public static IEnumerable<Type> notTableDefinedRecords
        {
            get
            {
                return Assembly.GetTypes().
                    Where(x => x.IsSubclassOf(typeof(Record))).
                    Where(x => !tables.ContainsKey(x)).
                    Where(x => !x.IsSubclassOf(typeof(User)) && !x.IsAbstract).
                    Where(x => !x.IsSubclassOf(typeof(Workplace))).
                    Where(x => !x.IsSubclassOf(typeof(Landmark)));
            }
        }
    }
}
