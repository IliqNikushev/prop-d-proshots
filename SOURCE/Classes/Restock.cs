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
        public List<RestockItem> Items { get { return Database.Where<RestockItem>("RestockItems.restock_id = {0}", this.ID); } }

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

        protected override void Create()
        {
            throw new NotImplementedException();
        }

        protected override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
