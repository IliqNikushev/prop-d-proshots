using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public abstract class Record : IEquatable<Record>, IComparable<Record>
    {
        [Column("Item_id")]
        public int ID { get; private set; }

        protected bool IsNew
        {
            get
            {
                return this.ID == 0;
            }
        }

        public string TableName { get { return Database.TableNameFor(this.GetType()); } }

        public Record(int id)
        {
            this.ID = id;
        }

        public void SendToDatabase()
        {
            if (this.IsNew)
                Save();
            else
                Update();
        }

        public static implicit operator bool(Record r)
        {
            return r != null;
        }

        public static bool operator ==(Record a, Record b)
        {
            if ((object)b == null && (object)a == null) return true;
            if ((object)b == null || (object)a == null) return false;
            return a.ID == b.ID;
        }

        public static bool operator !=(Record a, Record b)
        {
            return !(a == b);
        }

        protected abstract void Save();
        protected abstract void Update();

        public bool Equals(Record other)
        {
            if ((object)other == null) return false;
            return other.ID == this.ID;
        }

        public int CompareTo(Record other)
        {
            if ((object)other == null) return 1;

            return this.ID.CompareTo(other.ID);
        }
    }
}
