using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Receipt : Record
    {
        public int ID { get; private set; }
        private List<ReceiptItem> items;
        public List<ReceiptItem> Items
        {
            get
            {
                if (this.items == null)
                    if (this.ID == 0) 
                        this.items = new List<ReceiptItem>(); 
                    else
                        this.items = Database.Where<ReceiptItem>("PurchasedItems.receipt_id = {0}", this.ID);
                return this.items;
            }
        }
        public DateTime PurchasedOn { get; private set; }
        public Visitor PurchasedBy { get; private set; }
        public ShopJob Shop { get; private set; }

        public Receipt(int id, Visitor visitor, ShopJob shop, DateTime purchasedOn)
        {
            this.PurchasedBy = visitor;
            this.ID = id;
            this.PurchasedOn = purchasedOn;
            this.Shop = shop;
        }
    }
}
