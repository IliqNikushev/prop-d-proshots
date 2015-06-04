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

        public string TableName { get { return Database.TableNameFor(this); } }

        public Record(int id)
        {
            this.ID = id;
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

        public abstract Record Create();

        public override bool Equals(object obj)
        {
            if (obj is Record)
                return this.Equals(obj as Record);
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return this.ID + base.GetHashCode();
        }

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

        public override string ToString()
        {
            return this.GetType().Name + " # " + this.ID;
        }

        public void Delete(string where, params object[] parameters)
        {
            Database.Delete(this, where, parameters);
        }

        [Serializable]
        public class NotToBeSentToDatabaseException : Exception
        {
            public NotToBeSentToDatabaseException() : base(new System.Diagnostics.StackFrame(1).GetMethod().Name + "@" + new System.Diagnostics.StackFrame(1).GetMethod().DeclaringType.Name) { }
        }
    }
}
