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

        protected override void Save()
        {
            throw new NotImplementedException();
        }

        protected override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
