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
        public decimal TotalPrice { get; private set; }
        public int Times { get; private set; }

        public decimal Discount { get { return TotalPrice - (Times * PricePerItem); } }

        public ReceiptItem(int id, ShopItem item, Receipt receipt, int times, decimal pricePerItem, decimal totalPrice)
        {
            this.ID = id;
            this.Item = item;
            this.Times = times;
            this.Receipt = receipt;
            this.PricePerItem = pricePerItem;
            this.TotalPrice = totalPrice;
        }

        public override void Save()
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return this.Item.ToString() + string.Format(" {0} time{1} by {2}", this.Times, this.Times == 1 ? "" : "s", this.Receipt.PurchasedBy);
        }
    }
}
