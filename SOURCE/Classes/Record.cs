using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public abstract class Record
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

        protected abstract void Save();
        protected abstract void Update();
    }
}
