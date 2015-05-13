using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class RestockSelection : Record
    {
        public PurchasableItem Item { get; private set; }
        public int Times { get; private set; }

        public RestockSelection(PurchasableItem item, int times)
        {
            this.Item = item;
            this.Times = times;
        }

        public void Restock()
        {
            this.Item.Restock(this.Times);
        }
    }
}
