using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Restock : Record
    {
        public DateTime Date { get; private set; }
        public List<RestockItem> Items { get { return Database.Where<RestockItem>("|T|.restock_id = {0}", this.ID); } }

        public Restock() : this(0, DateTime.Now) { }

        public Restock(int id, DateTime date)
            : base(id)
        {
            this.Date = date;
        }

        public void Execute()
        {
            foreach (RestockItem item in this.Items)
                item.Execute();
        }

        public override Record Create()
        {
            return Database.Insert(this, "date", this.Date);
        }
    }
}
