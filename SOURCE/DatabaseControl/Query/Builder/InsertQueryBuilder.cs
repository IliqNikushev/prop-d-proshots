using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseControl
{
    using Property = System.Reflection.PropertyInfo;

    public class InsertQueryBuilder<T> : QueryBuilder<T> where T : Record
    {
        private Dictionary<string, List<object>> insertData = new Dictionary<string, List<object>>();

        protected override string Build
        {
            get
            {
                if (insertData.Count == 0) return "";
                StringBuilder valuesBuilder = new StringBuilder();
                IEnumerable<string> keys = insertData.Keys;
                int valuesCount = insertData[keys.First()].Count;
                for (int i = 0; i < valuesCount; i++)
                {
                    valuesBuilder.Append("(");
                    int currentKey = 0;
                    foreach (var key in keys)
                    {
                        valuesBuilder.Append(insertData[key][i]);
                        if (currentKey++ != insertData.Count - 1)
                            valuesBuilder.Append(", ");
                    }
                    valuesBuilder.Append(")");
                    if (i != valuesCount - 1)
                        valuesBuilder.Append(", ");
                }
                return string.Format("Insert Into {0}\n({1})\nValues\n{2}", base.tableName, string.Join(", ", keys), valuesBuilder.ToString());
            }
        }

        public InsertQueryBuilder(T record)
        {
            this.Insert(record);
        }

        public InsertQueryBuilder<T> Insert(Dictionary<string, List<object>> values)
        {
            IEnumerable<Property> properties = typeof(T).GetDatabaseSavedProperties();
            foreach (string key in values.Keys)
            {
                bool found = false;
                foreach (Property property in properties)
                {
                    if (property.Name == key)
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                    throw new PropertyNotInTableException(typeof(T), key);
            }

            if (this.insertData.Count == 0)
                this.insertData = values;
            else
                foreach (var insert in values)
                {
                    if (!this.insertData.ContainsKey(insert.Key))
                        this.insertData.Add(insert.Key, new List<object>());
                    this.insertData[insert.Key].AddRange(insert.Value);

                    //TODO : Check if other attributes also have enough values
                }
            return this;
        }

        public InsertQueryBuilder<T> Insert(params object[] values)
        {
            Dictionary<string, List<object>> data = new Dictionary<string, List<object>>();
            IEnumerable<Property> properties = typeof(T).GetDatabaseSavedProperties();
            int propertyCount = properties.Count();
            if (values.Length % propertyCount != 0) throw new InvalidOperationException("Not sufficient amount of values to insert to " + typeof(T).Name + ", " + (values.Length % propertyCount) + " / " + values.Length);

            foreach (var property in properties)
                data.Add(property.Name, new List<object>());

            for (int i = 0; i < values.Length; i++)
                foreach (var property in properties)
                    data[property.Name].Add(values[i++]);
            return Insert(data);
        }

        public InsertQueryBuilder<T> Insert(Dictionary<string, object> values)
        {
            Dictionary<string, List<object>> data = new Dictionary<string,List<object>>();
            foreach (var value in values)
                data.Add(value.Key, new List<object>() { value.Value });
            return Insert(data);
        }

        public InsertQueryBuilder<T> Insert(string data)
        {
            return Insert(data.Split(','));
        }

        public InsertQueryBuilder<T> Insert(T record)
        {
            return Insert(record.Attributes);
        }
    }
}
