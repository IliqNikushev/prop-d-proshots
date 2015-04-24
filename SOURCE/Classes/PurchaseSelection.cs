using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class PurchaseSelection
    {
        public PurchasableItem Item { get; private set; }
        public int Times { get; private set; }

        public PurchaseSelection(PurchasableItem item, int times)
        {
            this.Item = item;
            this.Times = times;
        }

        public void Purchase()
        {
            this.Item.Purchase(this.Times);
        }
    }
}
