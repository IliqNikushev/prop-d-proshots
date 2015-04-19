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
        public uint Times { get; private set; }

        public PurchaseSelection(PurchasableItem item, uint times)
        {
            this.Item = item;
            this.Times = times;
        }
    }
}
