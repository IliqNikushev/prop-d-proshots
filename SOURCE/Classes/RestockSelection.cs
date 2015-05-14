using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class RestockItem : Record
    {
        [Column("Restock_id")]
        public Restock Restock { get; private set; }

        public PurchasableItem Item { get; private set; }
        public int Times { get; private set; }

        public RestockItem(PurchasableItem item, int times, Restock restock)
        {
            this.Item = item;
            this.Times = times;
            this.Restock = restock;
        }

        public void Execute()
        {
            this.Item.Restock(this.Times);
        }
    }
}
