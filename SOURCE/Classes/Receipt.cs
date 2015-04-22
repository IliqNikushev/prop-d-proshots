using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Receipt
    {
        public List<PurchaseSelection> Items { get; private set; }
        public DateTime PurchasedOn { get; private set; }

        public Visitor Visitor
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public ShopJob Shop
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public Receipt(Visitor visitor, ShopJob shop, List<PurchaseSelection> items)
        {
            this.Visitor = visitor;
            this.Shop = shop;
            this.Items = items;
            this.PurchasedOn = DateTime.Now;
        }
    }
}
