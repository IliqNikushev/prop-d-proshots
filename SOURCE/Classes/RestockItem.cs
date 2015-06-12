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
        public ShopItem Item { get; private set; }
        public int Times { get; private set; }
        public decimal PricePerItem { get; private set; }
        public decimal Total { get; private set; }

        public RestockItem(ShopItem item, Restock restock, int times) : this(0, item, times, restock, item.Price, item.Price * times)
        {
        }

        public RestockItem(int id, ShopItem item, int times, Restock restock, decimal pricePerItem, decimal total) : base(id)
        {
            this.Item = item;
            this.Times = times;
            this.Restock = restock;
            this.PricePerItem = pricePerItem;
            this.Total = total;
        }

        public void Execute()
        {
            this.Item.Restock(this.Times);
        }

        public override Record Create()
        {
            Record r = Database.Insert(this, "restock_id, item_id, quantity, pricePerItem, total", this.Restock.ID, this.Item.ID, this.Times, this.PricePerItem, this.Total);
            this.Item.Restock(this.Times);

            return r;
        }
    }
}
