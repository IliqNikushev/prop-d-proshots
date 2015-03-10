using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Receipt
    {
        public User User { get; private set; }
        public Shop Shop { get; private set; }
        public List<PurchaseSelection> Items { get; private set; }
        public DateTime PurchasedOn { get; private set; }

        public Receipt(User user, Shop shop, List<PurchaseSelection> items)
        {
            this.User = user;
            this.Shop = shop;
            this.Items = items;
            this.PurchasedOn = DateTime.Now;
        }
    }
}
