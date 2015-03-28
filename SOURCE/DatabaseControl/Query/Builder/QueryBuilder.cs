using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseControl
{
    public abstract class QueryBuilder<T> where T:Record
    {
        protected string tableName
        {
            get
            {
                Type typeofT = typeof(T);
                Type[] generic = typeofT.GetGenericArguments();
                if (generic.Length > 0)
                    typeofT = generic[0];
                if (!Database.Tables.ContainsKey(typeofT))
                    throw new Database.TableNotFoundException(typeofT);
                return Database.Tables[typeofT];
            }
        }

        protected abstract string Build { get; }

        public QueryResult<T> Execute()
        {
            Database.LogQuery(this.Build);
#warning TODO : execute SQL, replace this with SQL result

            Type typeofT = typeof(T);
            Type[] generic = typeofT.GetGenericArguments();
            if (generic.Length > 0)
                typeofT = generic[0];

            return new QueryResult<T>(Database.records[typeofT]);
        }

        public static implicit operator QueryResult<T>(QueryBuilder<T> builder)
        {
            return builder.Execute();
        }

        [Serializable]
        public class PropertyNotInTableException : Exception
        {
            public PropertyNotInTableException(Type type, string propertyName) : base("Property not found " + type.Name + "." + propertyName) { }
        }
    }
}
