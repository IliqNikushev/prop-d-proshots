using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public abstract class Record
    {
        protected abstract object Identifier { get; }
        protected bool IsNew
        {
            get
            {
                if (Identifier.GetType().IsClass)
                    return Identifier == null;
                object d = Activator.CreateInstance(Identifier.GetType());
                return Identifier.Equals(d);
            }
        }

        public string TableName { get { return Database.TableNameFor(this.GetType()); } }

        public void SendToDatabase()
        {
            if (this.IsNew)
                Save();
            else
                Update();
        }

        protected abstract void Save();
        protected abstract void Update();
    }
}
