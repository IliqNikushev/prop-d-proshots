using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseControl
{
    public class SelectQueryBuilder<T> : WhereQueryBuilder<T> where T : Record
    {
        //TODO Group By
        //TODO JOIN
        public bool HasSelection { get { return selectColumns.Count > 0; } }

        private List<string> selectColumns = new List<string>();

        protected override string Build
        {
            get
            {
                if (this.selectColumns.Count == 0) return "";
                return string.Format("Select {0}\nFrom {1}", string.Join(", ", this.selectColumns), base.tableName) + base.Build;
            }
        }

        public SelectQueryBuilder<T> Select(string attributes)
        {
            string[] selectedAttributes = attributes.Split(',');

            foreach (var attribute in selectedAttributes)
            {
                if (attribute == "*")
                {
                    this.selectColumns.AddRange(typeof(T).GetDatabaseSavedProperties().Select(x => x.Name));
                }
                else
                {
                    //todo: validate
                    this.selectColumns.Add(attribute.Trim());
                }
            }
            return this;
        }

        public T[] Result { get { return this; } }

        public static implicit operator T[](SelectQueryBuilder<T> builder)
        {
            if (!builder.HasSelection)
                builder.Select("*");
            QueryResult<T> result = builder;
            
            return result;
        }
    }
}
