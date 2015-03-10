using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class PurchasableItem : Item
    {
       // public Shop ShopOfferedAt { get; private set; }

       // public PurchasableItem(int id, string name, decimal price, Shop shop) : base(id, name, price) 
        public PurchasableItem(int id, string name, decimal price) : base(id, name, price) 
        {
            //this.ShopOfferedAt = shop;
        }
    }
}
