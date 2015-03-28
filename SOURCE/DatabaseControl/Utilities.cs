using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseControl
{
    using Property = System.Reflection.PropertyInfo;
    using BindingFlags = System.Reflection.BindingFlags;

    public static class Utilities
    {
        private static readonly string[] commands = new string[] { "<=", ">=", "in", "=", "like", "and", "or" };

        private static List<int> FindIndexesOf(string stringToSearch, string searchFor, Func<string, int, bool> indexPicker = null)
        {
            List<int> foundIndexes = new List<int>();

            int index = 0;
            while (true)
            {
                index = stringToSearch.IndexOf(searchFor, index);
                if (index == -1) break;
                foundIndexes.Add(index);
                index += 1;
            }

            return foundIndexes;
        }

        private static List<string> SplitForCommand(List<string> items, int commandIndex)
        {
            if (commandIndex >= commands.Length)
                return items;

            List<string> result = new List<string>();
            string command = commands[commandIndex];
            for (int i = 0; i < items.Count; i++)
			{
                string str = items[i];
                if (commands.Contains(str)) { result.Add(str); continue; }
                if (str.Length == 0) continue;
                string strLowered = str.ToLower();

                List<int> foundIndexesOfTheCommand = FindIndexesOf(strLowered, command);
                if (foundIndexesOfTheCommand.Count == 0)
                {
                    result.Add(str);
                    continue;
                }

                int startIndex = 0;
                foreach (int foundIndex in foundIndexesOfTheCommand)
                {
                    int length = foundIndex - startIndex;

                    result.Add(str.Substring(startIndex, length));
                    result.Add(command);

                    startIndex = length;
                    startIndex += command.Length;
                }
                result.Add(str.Substring(foundIndexesOfTheCommand.Last() + command.Length));
            }
            if (result.Count == 0)
                result.AddRange(items);
            bool same = string.Join("", items) == string.Join("", result);
            items.Clear();
            
            return SplitForCommand(result, commandIndex + 1);
        }

        /// <summary>
        /// Returns the string separated by where operations 
        /// <para>ex: name='John' or name = 'Tim' -> [name ,=, 'John' ,or, name ,=, 'Tim'</para>
        /// <para>Requires that the data is valid ( passed through ConvertToValidSQL )</para>
        /// </summary>
        public static List<string> SplitForQuery(string str)
        {
            return SplitForCommand(new List<string>(){str}, 0);
        }

        /// <summary>
        /// Replaces ' with '' 
        /// <para>ex: name='It's a test' -></para>
        /// </summary>
        public static string ConvertForQuery(string str)
        {
            int firstIndex = str.IndexOf('\'');
            int lastIndex = str.LastIndexOf('\'');

            if (firstIndex == -1 ||
                lastIndex == -1 ||
                firstIndex == lastIndex ||
                firstIndex + 1 == lastIndex) return str;

            string result = "";
            result += str.Substring(0, firstIndex + 1);
            result += str.Substring(firstIndex + 1, lastIndex - firstIndex - 1).Replace("''", "'").Replace("'", "''");
            result += str.Substring(lastIndex, str.Length - lastIndex);

            return result;
        }

        /// <summary>
        /// Converts a string value<para>
        /// ex:(It''s time) to (It's time)</para> 
        /// </summary>
        public static string ConvertFromQuery(string str)
        {
            return str.Replace("''", "'");
        }
    }
    
    static class Extentions
    {
        private static Type notSavedInTableAttribute = typeof(NotDatabaseSavedAttribute);

        /// <summary>
        /// Gets all properties that do not have a NotDatabaseSavedAttribute and can be written and read
        /// </summary>
        public static IEnumerable<Property> GetDatabaseSavedProperties(this Type t)
        {
            Type[] generic = t.GetGenericArguments();
            if (generic.Length > 0)
                t = generic[0];
            return t.
                GetProperties(BindingFlags.Instance | BindingFlags.Public).
                Where(x=> 
                    !x.CustomAttributes.
                    Select(y=>y.AttributeType).
                    Contains(notSavedInTableAttribute) 
                    && x.CanRead && x.CanWrite);
        }
    }
}
