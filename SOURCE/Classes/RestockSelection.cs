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

        public RestockItem(ShopItem item, int times, Restock restock, decimal pricePerItem, decimal total)
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
    }
}
