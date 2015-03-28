using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseControl
{
    public class QueryResult<T> where T:Record
    {
        public int Rows 
        {
            get
            {
                if (this.Columns == 0) return 0;
                return this.Values[this.Values.Keys.First()].Length; 
            } 
        }
        public int Columns { get { return this.Values.Count; } }

        public Dictionary<string, object[]> Values { get; private set; }

        public QueryResult(Dictionary<string, object[]> values)
        {
            if (values == null) 
                this.Values = new Dictionary<string, object[]>();
            else
                this.Values = values;
        }

        public static implicit operator T[](QueryResult<T> queryResult)
        {
            T[] result = new T[queryResult.Rows];
            for (int i = 0; i < result.Length; i++)
            {
                Dictionary<string, object> values = new Dictionary<string, object>();
                foreach (var column in queryResult.Values)
                    values.Add(column.Key, column.Value[i]);
                result[i] = (T)Activator.CreateInstance(typeof(T));
                result[i].Build(values);
            }
            return result;
        }

        public static implicit operator T(QueryResult<T> queryResult)
        {
            T[] result = queryResult;
            if (result.Length == 1)
                return result[0];
            return null;
        }
    }
}
