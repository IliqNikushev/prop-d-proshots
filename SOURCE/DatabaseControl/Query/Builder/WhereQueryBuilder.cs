using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseControl
{
    using Property = System.Reflection.PropertyInfo;

    public abstract class WhereQueryBuilder<T> : QueryBuilder<T> where T : Record
    {
        private List<string> WhereClauses = new List<string>();

        protected override string Build
        {
            get 
            {
                if (this.WhereClauses.Count == 0) 
                    return "";
                StringBuilder clauseBuilder = new StringBuilder();
                foreach (var clause in this.WhereClauses)
                    clauseBuilder.Append(clause);
                return "\nWhere " + clauseBuilder.ToString(); 
            }
        }

        /// <summary>
        /// Where("name = 'test'","id = 3") or ("name = 'test' and id = 3)")
        /// </summary>
        public WhereQueryBuilder<T> Where(params string[] whereClauses)
        {
            List<string> clauses = new List<string>();
            foreach (string value in whereClauses)
                clauses.AddRange(Utilities.SplitForQuery(value).Select(x=>Utilities.ConvertForQuery(x)));
            
            IEnumerable<Property> properties = typeof(T).GetDatabaseSavedProperties();
            for (int i = 0; i < clauses.Count; i += 4)
            {
                string field = clauses[i].Trim();
                string operation = clauses[i + 1].Trim();
                string value = clauses[i + 2].Trim();

                if (field.ToLower() != "rownum")
                {
                    Property foundProperty = properties.First(x => x.Name.ToLower() == field.ToLower());
                    if (foundProperty == null)
                        throw new KeyNotFoundException("Filed not found for " + typeof(T).Name + "." + field);
                    if (foundProperty.PropertyType == typeof(string))
                    {
                        if (value[0] != '\'')
                            value = '\'' + value;
                        if (value[value.Length - 1] != '\'')
                            value += '\'';
                    }
                }
                if (operation == "in")
                {
                    //check if the value is an array  or sql
                }
                if (i + 4 < clauses.Count) value +=" "+ clauses[i+3]+" ";
                WhereClauses.Add(field + " " + operation + " " + value);
            }

            return this;
        }

        public WhereQueryBuilder<T> Where(Record record)
        {
            return this.Where(record.IndentificatorName + " = " + record.IdentificatorValue);
        }

        public QueryResult<T> Find(string where)
        {
            return this.Where(where + "and ROWNUM <= 1");
        }

        public QueryResult<T> Find(Record record)
        {
            return this.Where(record);
        }
    }
}
