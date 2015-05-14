using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class ReceiptItem : Record
    {
        public int ID { get; private set; }
        public ShopItem Item { get; private set; }
        public int Times { get; private set; }

        public ReceiptItem(int id, ShopItem item, int times)
        {
            this.ID = id;
            this.Item = item;
            this.Times = times;
        }
    }
}
