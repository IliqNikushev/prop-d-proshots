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
        //TOO : MYSQL commands
        //https://dev.mysql.com/doc/refman/5.1/en/non-typed-operators.html
        private static readonly string[] commands = new string[]
        {
            "!=", "<>","<=", ">=", "=", ">", "<",
            "like", "not like",
            "and", "or", 
            "in",
            "is not null", "is null", "is not","is",
            "not", "!"
        };
        private static readonly string[] functionCommands = new string[]
        {
            "+", "-", "*", "/", "%"
        };

        private static List<int> FindIndexesOf(string stringToSearch, string searchFor)
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
                for (int j = 0; j < foundIndexesOfTheCommand.Count; j++)
                {
                    int foundIndex = foundIndexesOfTheCommand[j];
                    int length = foundIndex - startIndex;
                    string beforeCommand = str.Substring(startIndex, length);

                    result.Add(beforeCommand);
                    result.Add(str.Substring(foundIndex, command.Length));

                    startIndex = foundIndex;
                    startIndex += command.Length;
                }
                result.Add(str.Substring(foundIndexesOfTheCommand.Last() + command.Length));
            }
            if (result.Count == 0)
                result.AddRange(items);
            items.Clear();
            
            return SplitForCommand(result, commandIndex + 1);
        }

        /// <summary>
        /// Returns the string separated by where operations 
        /// <para>ex: name='John' or name = 'Tim' -> [name ,=, 'John' ,or, name ,=, 'Tim'</para>
        /// </summary>
        /// <exception cref="InvalidQueryLengthException">Thrown</exception>
        /// <exception cref="InvalidQueryException">Thrown instead of IndexOutOfRangeException</exception>
        /// <exception cref="InvalidQueryCommandException"></exception>
        public static List<string> SplitForQuery(string query)
        {
            //TODO : FUNCTIONS
            List<string> result = SplitForCommand(new List<string>() { query }, 0);
            List<string> fixedResult = new List<string>();
            if (result.Count < 3)
                throw new InvalidQueryLengthException(query);
            if (result.Count == 3) return result;

            for (int i = 0; i < result.Count; i += 4)
            {
                if (i + 2 >= result.Count) // indexOutOfRange
                    throw new InvalidQueryException(query);

                string variable = result[i];
                while (true) // find next operator
                {
                    if (i >= result.Count - 1)
                        throw new InvalidQueryException(query);
                    if (variable.Trim().Length == 0)
                    {
                        variable += result[i + 1];
                        i++;
                        continue;
                    }
                    if (commands.Contains(result[i + 1].ToLower()))
                        break;
                    else
                        variable += result[i++ + 1];
                }
                string operation = result[i + 1];
                string value = result[i + 2];
                string andOr = "";
                if(i + 3 < result.Count)
                    andOr = result[i + 3];

                if (andOr.ToLower() != "and" && andOr.ToLower() != "or" && i + 3 < result.Count)
                {
                    value += andOr;
                    andOr = "";
                    while (true) // find next And Or
                    {
                        if (result.Count > i + 4)
                        {
                            if (result[i + 4].ToLower() != "and" && result[i + 4].ToLower() != "or")
                            {
                                value += result[i + 4];
                                i++;
                            }
                            else
                            {
                                string trimmed = value.Trim();
                                if (trimmed[0] == '\'' && trimmed[trimmed.Length - 1] == '\'')
                                {
                                    andOr = result[i + 4];
                                    i += 1;
                                    break;
                                }
                                else
                                {
                                    value += result[i + 4];
                                    i++;
                                }
                            }
                        }
                        else
                            break;
                    }
                }

                if (!commands.Contains(operation.ToLower()))
                    throw new InvalidQueryCommandException(operation, query);

                fixedResult.Add(variable);
                fixedResult.Add(operation);
                fixedResult.Add(value);
                fixedResult.Add(andOr);
            }

            return fixedResult;
        }

        public static string ConvertToQuery(string str)
        {
            return string.Join("", SplitForQuery(str).Select(x=>ConvertForQuery(x)));
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

        [Serializable]
        public class InvalidQueryException : Exception
        {
            public InvalidQueryException(string query) : base(query) { }
        }

        [Serializable]
        public class InvalidQueryCommandException : InvalidQueryException
        {
            public InvalidQueryCommandException(string command, string query) : base(command+"@"+query) { }
        }

        [Serializable]
        public class InvalidQueryLengthException : InvalidQueryException
        {
            public InvalidQueryLengthException(string query) : base(query) { }
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
