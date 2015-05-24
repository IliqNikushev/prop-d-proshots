using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Restock : Record
    {
        public int ID { get; private set; }
        public DateTime Date { get; private set; }
        public List<RestockItem> Items { get { return Database.Where<RestockItem>("RestockItems.restock_id = {0}", this.ID); } }

        public Restock(int id, DateTime date)
        {
            this.ID = id;
            this.Date = date;
        }

        public void Execute()
        {
            foreach (RestockItem item in this.Items)
                item.Execute();
        }

        public override void Save()
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
