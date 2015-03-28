using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseControl
{
    public abstract class Record
    {
        [NotDatabaseSaved]
        public bool IsChanged { get; protected set; }
        [NotDatabaseSaved]
        public bool IsNew { get; protected set; }
        public Dictionary<string, object> Attributes { get; private set; }

        public abstract string[] IdentificatorFields { get; }
        public string IndentificatorName { get { return string.Join(", ", IdentificatorFields); } }
        public abstract object IdentificatorValue { get; }

        public Record(Dictionary<string, object> values)
        {
            this.Attributes = values;
        }

        public Record()
        {
            this.Attributes = new Dictionary<string, object>();
            this.IsNew = true;
            foreach (var property in this.GetType().GetDatabaseSavedProperties())
                Attributes.Add(property.Name, null);
        }

        /// <summary>
        /// used when creating the record from the database
        /// </summary>
        public void Build(Dictionary<string, object> values)
        {
            foreach (var value in values)
            {
                object sqlValue = value.Value;

                if (sqlValue is string)
                    sqlValue = Utilities.ConvertFromQuery(sqlValue as string);

                if (!this.Attributes.ContainsKey(value.Key))
                    this.Attributes.Add(value.Key, value.Value);
                else
                    this.Attributes[value.Key] = value.Value;
            }
            this.IsNew = false;
        }

        [NotDatabaseSaved]
        public object this[string key]
        {
            get 
            {
                if (this.Attributes.ContainsKey(key))
                    throw new KeyNotFoundException("Unknown key for " + this.GetType().Name + "." + key);
                return this.Attributes[key]; 
            }
            set 
            {
                if (value != this.Attributes[key]) 
                    this.IsChanged = true; 
                this.Attributes[key] = value; 
            }
        }
    }

    public abstract class Record<T> : Record where T:Record
    {
        public void Save()
        {
            if (this.IsNew)
            {
                this.IsNew = false;
                new InsertQueryBuilder<Record<T>>(this).Execute();
            }
            else if (this.IsChanged)
            {
                this.IsChanged = false;
                new UpdateQueryBuilder<Record<T>>(this).Execute();
            }

            this.IsNew = false;
            this.IsChanged = false;
        }

        public static SelectQueryBuilder<T> All()
        {
            return new SelectQueryBuilder<T>().Select("*");
        }

        public static T Find(string whereClause)
        {
            return new SelectQueryBuilder<T>().Select("*").Find(whereClause);
        }

        public static SelectQueryBuilder<T> Where(params string[] whereClauses)
        {
            SelectQueryBuilder<T> builder = new SelectQueryBuilder<T>();
            builder.Where(whereClauses);
            return builder;
        }
    }
}
