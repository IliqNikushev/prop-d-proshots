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
        public decimal PricePerItem { get; private set; }
        public Receipt Receipt { get; private set; }
        public int Times { get; private set; }

        public ReceiptItem(int id, ShopItem item, Receipt receipt, int times, decimal pricePerItem)
        {
            this.ID = id;
            this.Item = item;
            this.Times = times;
            this.Receipt = receipt;
            this.PricePerItem = pricePerItem;
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
