using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class ShopItem : PurchasableItem
    {
        public ShopJob Shop { get; private set; }
        public int WarningLevel { get; private set; }
        public ShopItem(int id, decimal price, string brand, string model, string type, int inStock, int warningLevel, ShopJob shop)
            : base(id, price, brand, model, type, inStock)
        {
            this.Shop = shop;
            this.WarningLevel = warningLevel;
        }
    }
}
